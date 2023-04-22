using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : ChessPiece
{
    public override void MoveReady()
    {
        base.MoveReady();

        int x = square.index1;
        int y = square.index2;

        for (int i = x + 1, j = y + 1; i < 8 && j < 8; i++, j++)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            board.action.ChangeState(i, j, ChessSquare.SquareState.Move);           
        }

        for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            board.action.ChangeState(i, j, ChessSquare.SquareState.Move);

        }

        for (int i = x + 1, j = y - 1; i < 8 && j >= 0; i++, j--)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            board.action.ChangeState(i, j, ChessSquare.SquareState.Move);
        }

        for (int i = x - 1, j = y + 1; i >= 0 && j < 8; i--, j++)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            board.action.ChangeState(i, j, ChessSquare.SquareState.Move);
        }

        for (int i = x + 1; i < 8; i++)
        {
            if (board.Squares[i, y].piece != null)
                break;

            board.action.ChangeState(i, y, ChessSquare.SquareState.Move);           
        }

        for (int i = x - 1; i >= 0; i--)
        {
            if (board.Squares[i, y].piece != null)
                break;

            board.action.ChangeState(i, y, ChessSquare.SquareState.Move);
        }

        for (int i = square.index2 + 1; i < 8; i++)
        {
            if (board.Squares[x, i].piece != null)
                break;

            board.action.ChangeState(x, i, ChessSquare.SquareState.Move);  
        }

        for (int i = square.index2 - 1; i >= 0; i--)
        {
            if (board.Squares[x, i].piece != null)
                break;

            board.action.ChangeState(x, i, ChessSquare.SquareState.Move);
        }
    }
}
