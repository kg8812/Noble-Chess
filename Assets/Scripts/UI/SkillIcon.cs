using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SkillIcon : MonoBehaviour, IPointerDownHandler
{
    public Skill skill;
    public Image image;   
    public GameObject select;
       
    public void OnPointerDown(PointerEventData eventData)
    {       
        SkillIcon[] selects = UIManager.Instance.skillIcons;

        for (int i = 0; i < selects.Length; i++)
        {
            selects[i].select.SetActive(false);
        }

        select.SetActive(true);
        UIManager.Instance.skillDescription.Set(skill);
        UIManager.Instance.skillDescription.gameObject.SetActive(true);
        if (!ChessBoard.Instance.selected.piece.gameObject.CompareTag("Enemy"))
        {
            skill.Ready();
        }

    }

    public void Set()
    {
        image.sprite = skill.skillImage;
    }
}
