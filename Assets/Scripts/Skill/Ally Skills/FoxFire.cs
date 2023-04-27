using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxFire : Skill
{
    public override void Use()
    {
        base.Use();
        Attack(120);

        cr.GetComponent<FoxFireStack>().Count += 2;
    }

    public override void Ready()
    {
        base.Ready();

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Attack);
            }
        }
    }
}
