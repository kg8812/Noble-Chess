using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : Skill
{
    public override void Use()
    {
        base.Use();
        board.action.Swap(cr.GetComponent<ChessPiece>().square, targetSquare);

        Amplification amp = gameObject.AddComponent<Amplification>();
        AddBuff(amp, 3);
        Destroy(amp);       
    }

    public override void Ready()
    {
        base.Ready();

        for(int i = x - 1; i <= x + 1; i++)
        {
            for(int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Buff);
            }
        }
    }
}
