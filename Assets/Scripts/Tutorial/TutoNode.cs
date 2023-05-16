using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TutoNode : MonoBehaviour
{
    [Header("투명 이미지")]
    public Vector2 pos;
    public Vector2 size;

    [Header("화살표")]
    public Vector2 pos1;
    public Vector2 size1;

    public UnityEvent action;
    public Sprite sprite;

    public GameObject desc1;
    public GameObject desc2;
    
    public void Show(Image image,Image arrow,Sprite arrow1,Sprite arrow2)
    {
        image.rectTransform.anchoredPosition = pos;
        image.rectTransform.sizeDelta = size;
        image.sprite = sprite;

        if (size1.x > 0)
        {
            arrow.sprite = arrow2;
            arrow.rectTransform.anchoredPosition = pos1;           
            arrow.rectTransform.sizeDelta = size1;
            arrow.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = size1;
            float x = arrow.rectTransform.sizeDelta.x / 2;
            float y = arrow.rectTransform.sizeDelta.y / 2;

            arrow.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(-x,y);
        }
        else
        {           
            arrow.sprite = arrow1;
            arrow.rectTransform.anchoredPosition = new Vector2(780, -431);
            arrow.rectTransform.sizeDelta = new Vector2(223, 101);            
            arrow.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(223, 101);
            arrow.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        action?.Invoke();
    }

    public void One()
    {
        ChessBoard.Instance.Squares[1, 3].OnMouseDown();
    }

    public void Two()
    {
        UIManager.Instance.skillIcons[1].OnPointerDown(new PointerEventData(EventSystem.current));      
    }
    public void Three()
    {
        ChessBoard.Instance.Squares[0, 2].OnMouseDown();
    }

    public void Four()
    {
        ChessBoard.Instance.Squares[1, 3].OnMouseDown();
    }
    public void Five()
    {
        UIManager.Instance.moveButton.GetComponent<Button>().onClick.Invoke();
    }
    public void Six(bool isShow)
    {
        ChessBoard.Instance.Squares[2, 4].OnMouseDown();

        if (isShow)
        {
            desc1.SetActive(true);
        }
    }
    public void Seven()
    {
        UIManager.Instance.skillIcons[0].OnPointerDown(new PointerEventData(EventSystem.current));
        desc1.SetActive(false);
    }
    public void Eight()
    {
        UIManager.Instance.skillIcons[1].OnPointerDown(new PointerEventData(EventSystem.current));
    }
    public void Nine()
    {
        UIManager.Instance.skillIcons[0].OnPointerDown(new PointerEventData(EventSystem.current));
    }
    public void Ten()
    {
        ChessBoard.Instance.Squares[5, 4].OnMouseDown();
    }
    public void Eleven()
    {
        UIManager.Instance.allAttackButton.GetComponent<Button>().onClick.Invoke();
    }
    public void Twelve()
    {
        ChessBoard.Instance.Squares[5, 3].OnMouseDown();
        desc2.SetActive(true);
    }
    public void Thirteen()
    {
        TurnManager.Instance.EndTurn();
    }

    public void Off()
    {
        desc2.SetActive(false);
    }
}
