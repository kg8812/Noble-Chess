using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SkillIcon : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public Skill skill;
    public Image image;
    float clickTime = 0;
    bool isClicked = false;

    private void Update()
    {
        if (isClicked)
        {
            clickTime += Time.deltaTime;
        }

        if (clickTime > 0.5f)
        {
            UIManager.Instance.skillDescription.gameObject.SetActive(true);
            UIManager.Instance.skillDescription.Set(skill);
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        if (clickTime < 0.5f)
        {
            if (ChessBoard.Instance.selected.piece.gameObject.CompareTag("Enemy"))
                return;

            clickTime = 0;
            if (TurnManager.Instance.isSkillUsed)
            {
                UIManager.Instance.ShowText("이번턴에 스킬을 사용하였습니다.", Color.red);
                return;
            }
            if (skill.cr.isSkillUsed)
            {
                UIManager.Instance.ShowText("이미 스킬을 사용하였습니다.", Color.red);
                return;
            }
            if (skill.cr.GetComponent<Character>().isReserved)
            {
                UIManager.Instance.ShowText("이미 스킬을 예약하였습니다.", Color.red);
                return;
            }
            if (skill.CurCD > 0)
            {
                UIManager.Instance.ShowText("스킬 쿨타임입니다.", Color.red);
                return;
            }
            

                skill.Ready();            
        }
        UIManager.Instance.skillDescription.gameObject.SetActive(false);
        clickTime = 0;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
    }

    public void Set()
    {
        image.sprite = skill.skillImage;
    }
}
