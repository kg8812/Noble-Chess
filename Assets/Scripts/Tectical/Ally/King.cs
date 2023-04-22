using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override void MoveReady()
    {
        base.MoveReady();

        int x = square.index1;
        int y = square.index2;

        board.action.ActionInRange(1, x, y, ChessSquare.SquareState.Move);        

    }
}
