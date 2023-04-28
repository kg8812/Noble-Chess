using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : Creature,IOnNewTurn
{   
    public EnemySkill[] skills;
    public EnemySkill curSkill;

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i] = Instantiate(skills[i], GameObject.Find("Skill Collector").transform);
            skills[i].enemy = this;
            skills[i].cr = this;
            skills[i].CurCD = skills[i].StartCD;
        }
    }
    protected override void Start()
    {
        base.Start();       
    }

    public override void StartNewTurn()
    {
        base.StartNewTurn();       

        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].CurCD--;
        }

        PickSkill();
    }
    public bool CheckSkillUsable()
    {
        if (isSkillUsed) return false;

        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].IsUsable())
            {             
                return true;
            }
        }

        return false;
    }   
   
    protected virtual void OnDestroy()
    {
        try
        {
            if (hpBar != null)
                Destroy(hpBar.gameObject);

            for(int i = 0; i < skills.Length; i++)
            {
                if (skills[i] != null)
                    Destroy(skills[i].gameObject);
            }            
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }
    public void PickSkill()
    {
        curSkill = null;

        for (int i = 0; i < skills.Length; i++)
        {
            if (skills[i].CurCD == 0)
            {
                if (curSkill == null)
                {
                    curSkill = skills[i];
                }
                else if (curSkill.Priority < skills[i].Priority)
                {
                    curSkill = skills[i];
                }
            }
        }
    }
    public EnemySkill UseSkill()
    {
        curSkill?.Use();

        return curSkill;
    }
}
