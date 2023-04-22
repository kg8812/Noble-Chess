using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override void MoveReady()
    {
        base.MoveReady();
        int x = square.index1;
        int y = square.index2;

        if (isFirstMove)
        {
            if (board.action.CheckMovable(x + 1, y))
            {
                board.action.ChangeState(x + 2, y, ChessSquare.SquareState.Move);
            }
        }
       
        board.action.ChangeState(x + 1, y, ChessSquare.SquareState.Move);
    }

}
