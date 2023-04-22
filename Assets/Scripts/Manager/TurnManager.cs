﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnManager : Singleton<TurnManager>
{   
    public bool isMoved = false;
    public bool isSkillUsed = false;    

    Queue<Skill> skillQueue = new Queue<Skill>();
    bool isSkill = false;
    public Skill selectedSkill = null;
    public void StartTurn()
    {       
        isMoved = false;
        selectedSkill = null;
        isSkillUsed = false;
        ChessBoard.Instance.Cancel();
        ChessBoard.Instance.ColorReset();
        UIManager.Instance.ShowText("플레이어의 턴입니다.", Color.green);

        for (int i = 0; i < ChessBoard.Instance.ally.Count; i++)
        {
            IOnNewTurn[] nt = ChessBoard.Instance.ally[i].GetComponents<IOnNewTurn>();

            for(int j = 0; j < nt.Length; j++)
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
            ChessBoard.Instance.ally[i].character?.ResetReserve();
        }
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

                if (skill.isSpecial)
                {
                    yield return StartCoroutine(SkillEffect(skill));
                }
                else
                {
                    yield return StartCoroutine(UIManager.Instance.SetSkillEffect(skill));
                }
                skill.Use();

                yield return new WaitForSeconds(0.5f);
                skill.targetSquare = null;
                skill.targetPiece = null;
            }         
            isSkill = false;
        }
        Time.timeScale = 1;
    }

    public IEnumerator SkillEffect(Skill skill)
    {
        Vector3 pos = skill.cr.transform.position - Camera.main.transform.position;
        Camera.main.transform.position += pos * 0.7f;
        GameObject canvas = GameObject.Find("Canvas").transform.Find("UIs").gameObject;
        canvas.SetActive(false);
        
        yield return StartCoroutine(UIManager.Instance.SetSpecialSkillEffect(skill));
        
        Camera.main.transform.position -= pos * 0.7f;
        canvas.SetActive(true);
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

        for(int i = 0; i < ChessBoard.Instance.ally.Count; i++)
        {
            IOnEndTurn[] et = ChessBoard.Instance.ally[i].GetComponents<IOnEndTurn>();

            for(int j = 0; j < et.Length; j++)
            {
                et[j].EndTurn();
            }
        }
        GameManager.Instance.ChangeTurn();
    }
}