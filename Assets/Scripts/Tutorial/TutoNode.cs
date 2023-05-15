using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TutoNode : MonoBehaviour
{
    public Vector2 pos;
    public Vector2 size;
    public UnityEvent action;
    public Sprite sprite;

    int count = 0;

    public GameObject desc1;
    public GameObject desc2;
    
    public void Show(Image image)
    {
        image.rectTransform.anchoredPosition = pos;
        image.rectTransform.sizeDelta = size;
        image.sprite = sprite;
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
    }
    public void Thirteen()
    {
        TurnManager.Instance.EndTurn();
    }
}
