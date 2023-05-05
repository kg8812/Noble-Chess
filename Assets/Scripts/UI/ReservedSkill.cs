using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReservedSkill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Skill skill;
    StatusDescription description { get { return UIManager.Instance.statusDescription; } }
    public void OnPointerExit(PointerEventData eventData)
    {
        description.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {        
        description.gameObject.SetActive(true);
        description.transform.position = transform.position;
        description.Set(skill);
    }   

    public void Set(Skill bf)
    {
        skill = bf;       
    }

    private void OnDisable()
    {
        if(UIManager.Instance!= null)
        description.gameObject.SetActive(false);
    }
}
