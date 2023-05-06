using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image hpBar;
    public Creature cr;
    public Image whiteBar;
    RectTransform rectTransform;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        transform.SetAsFirstSibling();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(cr.uiPos.position);
        hpBar.fillAmount = cr.CurHp / cr.MaxHp;
        float width = rectTransform.rect.width;
        whiteBar.fillAmount = cr.barrier / cr.MaxHp;

        float pos = width * hpBar.fillAmount;

        if ((hpBar.fillAmount + whiteBar.fillAmount) > 1)
        {
            pos -= (hpBar.fillAmount + whiteBar.fillAmount - 1) * width;
        }
        whiteBar.rectTransform.anchoredPosition = new Vector2(pos, 0);

    }
}
