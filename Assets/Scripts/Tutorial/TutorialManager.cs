using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [TextArea] public List<string> list = new List<string>();
    public List<TutoNode> tutoNodes= new List<TutoNode>();
    public Text text;
    public RectTransform panel;
    public Image image;
    public GameObject cover;
    public GameObject button;
    public GameObject uiCover;
    public Image arrow;
    public Sprite arrow1;
    public Sprite arrow2;

    int count = 0;
    public void Next()
    {
        if (TurnManager.Instance.isSkill)
        {
            return;
        }
        if (count < list.Count)
        {
            text.text = list[count];
            tutoNodes[count].Show(image,arrow,arrow1,arrow2);
            count++;
            panel.position = Vector3.zero;
            panel.sizeDelta = new Vector2(1920, 1080);
        }
        else
        {
            panel.gameObject.SetActive(false);
            cover.SetActive(false);
            text.transform.parent.gameObject.SetActive(false);
            button.SetActive(false);
            uiCover.SetActive(false);
        }
    }

    private void Start()
    {
        count = 0;
        Next();
    }   
}
