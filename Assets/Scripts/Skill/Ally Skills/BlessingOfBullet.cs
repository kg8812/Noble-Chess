using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingOfBullet : Skill
{
    public override void Ready()
    {
        base.Ready();

        for (int i = x + 1; i < 8; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Attack);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        float dmg = 120 + cr.GetComponent<BulletBuff>().count * 5;

        Attack(dmg);

        cr.GetComponent<BulletBuff>().count = 0;
    }
}
