using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySkill : Skill
{
    public Enemy enemy;
    protected List<ChessSquare> targets = new List<ChessSquare>();

    [Header("스킬 우선도 (높을수록 빨리씀)")]
    [SerializeField] int priority;
    public int Priority { get { return priority; } }
    protected new ChessSquare square 
    { 
        get { return enemy.GetComponent<ChessPiece>().square; } 
    }

    public virtual bool IsUsable()
    {       
        if (IsCD) return false;
        
        return CheckTargets();               
    }

    public override void Use()
    {
        base.Use();
        targetSquare = null;
        AddTargets();           
    }
    protected virtual void AddTargets()
    {
        targets.Clear();
    }
    protected virtual void PickTarget()
    {
        if (targets.Count == 0) return;

        int index = 0;
        
        float min = targets[0].piece.character.CurHp;

        for (int i = 1; i < targets.Count; i++)
        {
            float hp = targets[i].piece.character.CurHp;

            if (min > hp)
            {
                min = hp;
                index = i;
            }
        }

        targetSquare = targets[index];
    }
    public abstract bool CheckTargets();
    public abstract bool CheckTargets(ChessSquare square);
    public abstract bool CheckTargets(int idx1,int idx2);

}
