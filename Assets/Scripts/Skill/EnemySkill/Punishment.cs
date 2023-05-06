using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punishment : EnemySkill
{
    public override bool CheckTargets()
    {
        int x = square.index1;
        int y = square.index2;

        for (int i = y - 1; i <= y + 1; i++)
        {            
            if (board.action.CheckAttackable(x - 1, i, false))
            {               
                return true;
            }
        }

        return false;
    }

    public override bool CheckTargets(ChessSquare square)
    {
        int x = square.index1;
        int y = square.index2;

        for (int i = y - 1; i < y + 1; i++)
        {
            if (board.action.CheckAttackable(x - 1, i, false))
            {
                return true;
            }
        }

        return false;
    }

    public override bool CheckTargets(int idx1, int idx2)
    {
        int x = idx1;
        int y = idx2;

        for (int i = y - 1; i < y + 1; i++)
        {
            if (board.action.CheckAttackable(x - 1, i, false))
            {               
                return true;
            }
        }

        return false;
    }

    protected override void AddTargets()
    {
        base.AddTargets();

        int x = square.index1;
        int y = square.index2;

        for (int i = y - 1; i < y + 1; i++)
        {
            if (board.action.CheckAttackable(x - 1, i, false))
            {
                targets.Add(board.Squares[x - 1, i]);
            }
        }
    }
    public override void Use()
    {
        base.Use();
        PickTarget();
        if (targetSquare == null) return;

        Creature p = targetSquare.piece.character;

        float dmg = targetSquare.piece.GetComponent<IOnDamage>().OnHit(enemy.Atk * 1.3f);

        GameObject obj = Instantiate(effect, cr.transform);
        obj.transform.position = targetSquare.transform.position;      
        Destroy(obj,clip.length);
        enemy.OnAttack(p, enemy.Atk * 1.3f, dmg);
    }


    public override IEnumerator ShowEffect()
    {
        yield return null;
    }
}
