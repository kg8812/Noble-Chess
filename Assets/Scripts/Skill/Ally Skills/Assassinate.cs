using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assassinate : Skill
{
    public override void Ready()
    {
        base.Ready();

        for (int i = x + 1; i <= x + 2; i++)
        {
            board.action.ChangeState(i, y, ChessSquare.SquareState.Attack);
        }
    }

    public override void Use()
    {
        base.Use();
        int dmg = 160;

        if (targetPiece.GetComponent<RBlood>() != null)
        {
            dmg *= 2;
            Destroy(targetPiece.GetComponent<RBlood>());
        }

        Attack(dmg);
    }  
}
