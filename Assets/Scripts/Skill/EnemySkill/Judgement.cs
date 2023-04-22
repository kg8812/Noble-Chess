using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : EnemySkill
{
    public override bool CheckTargets()
    {
        int x = square.index1;
        int y = square.index2;

        for (int i = x - 1; i <= x - 2; i--)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (board.action.CheckAttackable(i, j, false))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public override bool CheckTargets(ChessSquare square)
    {
        int x = square.index1;
        int y = square.index2;

        for (int i = x - 1; i <= x - 2; i--)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (board.action.CheckAttackable(i, j, false))
                {
                    return true;
                }
            }
        }

        return false;
    }

    public override bool CheckTargets(int idx1, int idx2)
    {
        int x = idx1;
        int y = idx2;

        for (int i = x-1; i <= x - 2; i--)
        {
            for (int j = y-1; j <= y + 1; j++)
            {
                if (board.action.CheckAttackable(i, j, false))
                {
                    return true;
                }
            }
        }

        return false;
    }

    protected override void AddTargets()
    {
        base.AddTargets();
        int x = square.index1;
        int y = square.index2;

        for (int i = x-1; i >= x - 2; i--)
        {
            for (int j = y-1; j <= y + 1; j++)
            {
                if (board.action.CheckAttackable(i, j, false))
                {
                    targets.Add(board.Squares[i, j]);
                }
            }
        }
    }

    public override void Use()
    {
        base.Use();

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i]?.piece == null) continue;

            Creature p = targets[i].piece.character;

            float dmg = targets[i].piece.GetComponent<IOnDamage>().OnHit(enemy.Atk * 1.7f);
            enemy.OnAttack(p, enemy.Atk * 1.7f, dmg);

        }
    }
}
