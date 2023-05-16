using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : Singleton<TurnManager>
{

    public bool isMoved = false;
    public bool isSkillUsed = false;

    Queue<Skill> skillQueue = new Queue<Skill>();
    public bool isSkill { get; private set; } = false;
    public Skill selectedSkill = null;
    int count = 0;

    public void StartTurn()
    {
        count++;
        UIManager.Instance.turnCount.text = count.ToString();
        isMoved = false;
        selectedSkill = null;
        isSkillUsed = false;
        ChessBoard.Instance.Cancel();
        ChessBoard.Instance.ColorReset();
        UIManager.Instance.ShowTurnImage(false);

        for (int i = 0; i < ChessBoard.Instance.ally.Count; i++)
        {
            IOnNewTurn[] nt = ChessBoard.Instance.ally[i].GetComponents<IOnNewTurn>();

            for (int j = 0; j < nt.Length; j++)
            {
                nt[j].StartNewTurn();
            }
        }
    }

    public void ReadyToMove()
    {
        if (!isMoved)
            ChessBoard.Instance.selected.piece.MoveReady();
        else
        {
            UIManager.Instance.ShowText("더 이상 이동할 수 없습니다.", Color.red);
        }
    }

    public void CancelSkill()
    {
        skillQueue.Clear();
        selectedSkill = null;
        UIManager.Instance.allAttackButton.SetActive(false);
        UIManager.Instance.attackCancelButton.SetActive(false);
        UIManager.Instance.ShowText("예약을 취소합니다.", Color.red);
        UIManager.Instance.behaviourOption.SetActive(false);

        for (int i = 0; i < ChessBoard.Instance.ally.Count; i++)
        {
            if (ChessBoard.Instance.ally[i].character == null) continue;

            ChessBoard.Instance.ally[i].character.ResetReserve();
        }
       
        UIManager.Instance.bookUI.Cancel();
        ChessBoard.Instance.Cancel();
        ChessBoard.Instance.ColorReset();
    }

    public void ReserveSkill(Skill sk)
    {
        skillQueue.Enqueue(sk);
        UIManager.Instance.allAttackButton.SetActive(true);
        UIManager.Instance.attackCancelButton.SetActive(true);
        selectedSkill = null;
    }

    public void ReserveSkill()
    {
        skillQueue.Enqueue(selectedSkill);
        UIManager.Instance.allAttackButton.SetActive(true);
        UIManager.Instance.attackCancelButton.SetActive(true);
        UIManager.Instance.bookUI.Add(selectedSkill);

        selectedSkill = null;
    }

    public void StartUsingSkills()
    {
        StartCoroutine(UseSkills());
    }
    IEnumerator UseSkills()
    {
        if (!isSkill)
        {
            isSkillUsed = true;
            UIManager.Instance.allAttackButton.SetActive(false);
            UIManager.Instance.attackCancelButton.SetActive(false);

            isSkill = true;
            while (skillQueue.Count > 0)
            {
                Skill skill = skillQueue.Dequeue();


                yield return StartCoroutine(UIManager.Instance.SetSkillProduction(skill));


                yield return StartCoroutine(skill.ShowEffect());
                skill.Use();
                UIManager.Instance.bookUI.Remove();
                yield return new WaitForSeconds(0.5f);
                skill.targetSquare = null;
                skill.targetPiece = null;
            }
            isSkill = false;
        }
        Time.timeScale = 1;
    }

    public IEnumerator SkillProduction(Skill skill)
    {                    
        yield return StartCoroutine(UIManager.Instance.SetSpecialSkillEffect(skill));        
    }
    public void EndTurn()
    {
        if (!GameManager.Instance.isPlayerTurn) return;

        if (isSkill)
        {
            UIManager.Instance.ShowText("스킬 사용 중입니다.", Color.red);
            return;
        }
        else if (skillQueue.Count > 0)
        {
            UIManager.Instance.ShowText("스킬 예약 중입니다.", Color.red);
            return;
        }

        for (int i = 0; i < ChessBoard.Instance.ally.Count; i++)
        {
            IOnEndTurn[] et = ChessBoard.Instance.ally[i].GetComponents<IOnEndTurn>();

            for (int j = 0; j < et.Length; j++)
            {
                et[j].EndTurn();
            }
        }
        GameManager.Instance.ChangeTurn();
    }
}
