using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;


public class EnemyTurnManager : Singleton<EnemyTurnManager>
{
    bool isSkillMove = false;   // 이동후 스킬 사용가능 여부
    ChessBoard board { get { return ChessBoard.Instance; } } // 체스판
    List<ChessPiece> pieces { get { return board.enemy; } } // 적 기물목록
    public ChessPiece selected;     // 이동할 기물   
    public List<ChessPiece> moveList = new List<ChessPiece>(); // 이동 목록
    Queue<ChessPiece> skillQueue = new Queue<ChessPiece>(); // 스킬 예약 목록

    public void StartTurn()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i] == null) continue;

            IOnNewTurn[] nt = pieces[i].GetComponents<IOnNewTurn>();

            for (int j = 0; j < nt.Length; j++)
            {
                nt[j].StartNewTurn();
            }
        }

        ResetStates();
        UIManager.Instance.ShowTurnImage(true);

        StartCoroutine(ProcessTurn());
    }

    IEnumerator ProcessTurn()
    {
        yield return StartCoroutine(UseImmediateSkills());

        yield return new WaitForEndOfFrame();
        CheckSkills();
        SkillUsableAfterMove();
        PickMoveTectical();

        yield return new WaitForSeconds(1);

        if (selected != null) Move();

        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(UseSkills());

        for (int i = 0; i < pieces.Count; i++)
        {
            IOnEndTurn[] et = pieces[i].GetComponents<IOnEndTurn>();

            for (int j = 0; j < et.Length; j++)
            {
                et[j].EndTurn();
            }
        }
        GameManager.Instance.ChangeTurn();
    }
    void ResetStates()
    {
        moveList.Clear();
        skillQueue.Clear();
        isSkillMove = false;
        selected = null;
    }

    IEnumerator UseImmediateSkills()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            EnemySkill skill = pieces[i].GetComponent<Enemy>().curSkill;

            if (skill != null && skill.IsUsable() && skill.isImmediate)
            {

                yield return StartCoroutine(UIManager.Instance.SetSkillProduction(skill));

                yield return skill.ShowEffect();
                skill.Use();
            }
        }
    }
    public void StartJob()
    {

    }

    void CheckSkills()
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (pieces[i] == null) continue;

            if (pieces[i].GetComponent<Enemy>().CheckSkillUsable())
            {
                skillQueue.Enqueue(pieces[i]);
            }
            else moveList.Add(pieces[i]);
        }
    }

    IEnumerator UseSkills()
    {
        while (skillQueue.Count > 0)
        {
            Skill skill = skillQueue.Dequeue()?.GetComponent<Enemy>().curSkill;

            if (skill == null) continue;

            yield return StartCoroutine(UIManager.Instance.SetSkillProduction(skill));
            yield return skill.ShowEffect();

            skill.Use();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SkillUsableAfterMove()
    {
        List<ChessPiece> list = new List<ChessPiece>();

        for (int i = 0; i < moveList.Count; i++)
        {
            if (moveList[i].GetComponent<EnemyChessPiece>().CheckSkillAfterMove())
            {
                list.Add(moveList[i]);
            }
        }

        if (list.Count > 0)
        {
            moveList = list;
            isSkillMove = true;
        }
    }

    void PickMoveTectical()
    {
        int min = 100;

        if (!isSkillMove)
        {
            for (int i = 0; i < moveList.Count; i++)
            {
                moveList[i].GetComponent<EnemyChessPiece>().CheckMoves();
                moveList[i].GetComponent<EnemyChessPiece>().GetShortestMove();
            }

            for (int i = 0; i < moveList.Count; i++)
            {
                if (moveList[i].GetComponent<EnemyChessPiece>().mList.Count == 0 || !moveList[i].isMovable)
                    continue;

                int dist = moveList[i].square.GetDistToAlly();

                if (min > dist)
                {
                    min = dist;
                    selected = moveList[i];
                }
            }
        }
        else
        {
            for (int i = 0; i < moveList.Count; i++)
            {
                if (!moveList[i].isMovable) continue;

                if (min > moveList[i].GetComponent<EnemyChessPiece>().GetShortestMove())
                {
                    min = moveList[i].GetComponent<EnemyChessPiece>().GetShortestMove();
                    selected = moveList[i];
                }
            }
        }

    }

    void Move()
    {

        int idx1 = selected.GetComponent<EnemyChessPiece>().mIdx1;
        int idx2 = selected.GetComponent<EnemyChessPiece>().mIdx2;

        StartCoroutine(selected.StartMove(idx1, idx2));

        if (selected.GetComponent<Enemy>().CheckSkillUsable())
        {
            skillQueue.Enqueue(selected);
        }
    }
}
