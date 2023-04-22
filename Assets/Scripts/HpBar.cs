using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image hpBar;
    public Creature cr;

    // Update is called once per frame
    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(cr.uiPos.position);
        hpBar.fillAmount = cr.CurHp / cr.MaxHp;
    }
}
