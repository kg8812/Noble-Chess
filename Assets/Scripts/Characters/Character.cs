using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character : Creature,IOnNewTurn
{
    public bool isReserved { get; private set; }
    protected ChessPiece piece { get { return GetComponent<ChessPiece>(); } }
    protected ChessBoard board { get { return ChessBoard.Instance; } }
    public Enemy target;     
  
    public Skill[] skills;

    protected override void Awake()
    {
        base.Awake();
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i] = Instantiate(skills[i], GameObject.Find("Skill Collector").transform);
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

        ResetReserve();
        for (int i = 0; i < skills.Length; i++)
        {
            skills[i].CurCD--;
        }
    }
    public void ResetReserve()
    {
        isReserved = false;
        target = null;
    }

    public virtual void ReadyToAttack()
    {

    }
    public void ReserveSkill()
    {
        isReserved = true;       
        board.ColorReset();
        board.Cancel();
        TurnManager.Instance.ReserveSkill();
    }
    public virtual void Attack(Enemy target,float ratio)
    {
        float dmg = Atk * ratio/100;
        
        IOnAttack[] onAttacks = GetComponents<IOnAttack>();
        
        dmg = target.GetComponent<IOnDamage>().OnHit(dmg);

        for (int i = 0; i < onAttacks.Length; i++)
        {
            onAttacks[i].OnAttack(target, Atk, dmg);
        }
    }  

    protected virtual void OnDestroy()
    {
        try
        {
            if (ChessBoard.Instance != null)
            ChessBoard.Instance.ally.Remove(piece);

            if (hpBar != null)
                Destroy(hpBar.gameObject);
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
