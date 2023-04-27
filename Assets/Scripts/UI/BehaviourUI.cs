using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BehaviourUI : MonoBehaviour
{
    [SerializeField] SkillDescription sd;
    [SerializeField] Image hpbar;
    [SerializeField] GameObject statusPref;

    ChessPiece pi { get { return ChessBoard.Instance.selected.piece; } }
    private void OnEnable()
    {       
        UIManager.Instance.illustration.sprite = pi.GetComponent<Creature>().portrait;
        bool isEnemy = pi.gameObject.CompareTag("Enemy");

        UIManager.Instance.moveButton.SetActive(!isEnemy);
        UIManager.Instance.cancelButton.SetActive(!isEnemy);

        Skill[] skills;

        SkillIcon[] selects = UIManager.Instance.skillIcons;

        for(int i = 0; i < selects.Length; i++)
        {
            selects[i].select.SetActive(false);
        }

        SetStatusIcons();

        sd.Set();

        if (isEnemy)
        {
            skills = ChessBoard.Instance.selected.piece.GetComponent<Enemy>().skills;
        }
        else
        {
            skills = ChessBoard.Instance.selected.piece.character.skills;
        }
        for (int i = 0; i < skills.Length; i++)
        {
            UIManager.Instance.skillIcons[i].skill = skills[i];
            UIManager.Instance.skillIcons[i].Set();
        }
        for(int i = skills.Length; i < UIManager.Instance.skillIcons.Length; i++)
        {
            UIManager.Instance.skillIcons[i].skill = null;
        }
        for(int i = 0; i < UIManager.Instance.skillIcons.Length; i++)
        {
            if (UIManager.Instance.skillIcons[i].skill == null)
            {
                UIManager.Instance.skillIcons[i].gameObject.SetActive(false);
            }
            else
            {
                UIManager.Instance.skillIcons[i].gameObject.SetActive(true);

            }
        }
    }
    
    void SetStatusIcons()
    {
        Creature cr = pi.GetComponent<Creature>();

        Buff[] buffs = cr.GetComponents<Buff>();

        for(int i = 0; i < buffs.Length; i++)
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
}
