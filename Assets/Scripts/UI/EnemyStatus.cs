﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStatus : MonoBehaviour
{
    ChessBoard board { get { return ChessBoard.Instance; } }

    [SerializeField] Image skillImage;
    [SerializeField] Text skillName;
    [SerializeField] Text skillDescription;
    [SerializeField] GameObject nextSkill;
    [SerializeField] GameObject statusPref;
    [SerializeField] Image portrait;
    [SerializeField] Text enemyDescription;
    [SerializeField] Image hpbar;
    [SerializeField] Image skillRange;
    [SerializeField] Image tecticalImage;
    [SerializeField] Text enemyName;

    ChessPiece pi { get { return ChessBoard.Instance.selected.piece; } }

    void OnEnable()
    {
        Enemy enemy = pi.GetComponent<Enemy>();
        enemyName.text = enemy.Name;
        enemyDescription.text = enemy.description;
        EnemySkill skill = enemy.NextSkill();
        portrait.sprite = pi.GetComponent<Creature>().portrait;
        tecticalImage.sprite = pi.tecticalImage;
        if (skill != null)
        {
            nextSkill.SetActive(true);
            skillImage.sprite = skill.skillImage;
            skillName.text = skill.skillName;
            skillDescription.text = skill.description;

            skillRange.gameObject.SetActive(skill.range != null);
            skillRange.sprite = skill.range;
        }
        else
        {
            nextSkill.SetActive(false);
        }

        SetStatusIcons();
    }
    void SetStatusIcons()
    {
        Creature cr = pi.GetComponent<Creature>();

        Buff[] buffs = cr.GetComponents<Buff>();

        for (int i = 0; i < buffs.Length; i++)
        {
            if (buffs[i].count > 100) continue;

            StatusEffect se = Instantiate(statusPref, transform.Find("Status Effects").transform).GetComponent<StatusEffect>();
            se.Set(buffs[i]);
        }
    }
    private void Update()
    {
        hpbar.fillAmount = pi.GetComponent<Creature>().CurHp / pi.GetComponent<Creature>().MaxHp;
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
}
