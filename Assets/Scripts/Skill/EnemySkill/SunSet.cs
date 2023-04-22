using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSet : EnemySkill
{
    [SerializeField] float atk;

    public override bool CheckTargets()
    {
        return true;
    }

    public override bool CheckTargets(ChessSquare square)
    {
        return true;
    }

    public override bool CheckTargets(int idx1, int idx2)
    {
        return true;
    }

    protected override void AddTargets()
    {
        base.AddTargets();

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if (board.Squares[i, j].piece != null && !board.Squares[i, j].piece.gameObject.CompareTag("Enemy"))
                {
                    targets.Add(board.Squares[i, j]);
                }
            }
        }
    }

    public override void Use()
    {
        base.Use();
        for(int i = 0; i < targets.Count; i++)
        {
            if (targets[i]?.piece == null) continue;

            Creature p = targets[i].piece.character;

            float dmg = targets[i].piece.GetComponent<IOnDamage>().OnHit(enemy.Atk * atk);
            enemy.OnAttack(p, enemy.Atk * atk, dmg);
        }
    }
}
