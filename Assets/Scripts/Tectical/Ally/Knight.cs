using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override void MoveReady()
    {
        base.MoveReady();

        int x = square.index1;
        int y = square.index2;

        board.action.ChangeState(x + 2, y - 1,ChessSquare.SquareState.Move);
        board.action.ChangeState(x + 2, y + 1,ChessSquare.SquareState.Move);
        board.action.ChangeState(x - 2, y - 1,ChessSquare.SquareState.Move);
        board.action.ChangeState(x - 2, y + 1,ChessSquare.SquareState.Move);
        board.action.ChangeState(x - 1, y + 2,ChessSquare.SquareState.Move);
        board.action.ChangeState(x + 1, y + 2,ChessSquare.SquareState.Move);
        board.action.ChangeState(x - 1, y - 2,ChessSquare.SquareState.Move);
        board.action.ChangeState(x + 1, y - 2,ChessSquare.SquareState.Move);
    }

   

}
