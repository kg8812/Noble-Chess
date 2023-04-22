using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfBonding : Skill
{ 
    ChessPiece target;
    bool isFirst = true;

    public override void Ready()
    {
        base.Ready();

        isTwice = true;
        isFirst = true;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Buff);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        if (isFirst)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board.action.ChangeState(i, j, ChessSquare.SquareState.Place);
                }
            }            
            target = targetPiece;
            isFirst = false;
        }
        else if (!isFirst)
        {
            target.StartMove(targetSquare);
            isTwice = false;
            isFirst = true;
            target = null;
        }
    }
}
