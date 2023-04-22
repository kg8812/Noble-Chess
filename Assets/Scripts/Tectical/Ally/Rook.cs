using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override void MoveReady()
    {
        base.MoveReady();
        int x = square.index1;
        int y = square.index2;

        for (int i = x + 1; i < 8; i++)
        {
            if (board.Squares[i, y].piece != null)
                break;

            board.action.ChangeState(i, y,ChessSquare.SquareState.Move);
        }

        for (int i = x - 1; i >= 0; i--)
        {
            if (board.Squares[i, y].piece != null)
                break;
            board.action.ChangeState(i, y, ChessSquare.SquareState.Move);

        }

        for (int i = y + 1; i < 8; i++)
        {
            if (board.Squares[x, i].piece != null)
                break;
            board.action.ChangeState(x, i, ChessSquare.SquareState.Move);

        }

        for (int i = y - 1; i >= 0; i--)
        {
            if (board.Squares[x, i].piece != null)
                break;

            board.action.ChangeState(x, i, ChessSquare.SquareState.Move);
        }
    }
}
