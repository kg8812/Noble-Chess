using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KramavWhip : Skill
{
    List<ChessSquare> squares = new List<ChessSquare>();
    public override void Ready()
    {
        base.Ready();

        squares.Clear();

        if (board.action.ChangeState(x + 1, y - 1, ChessSquare.SquareState.Range))
        {
            squares.Add(board.Squares[x + 1, y - 1]);
        }
        if (board.action.ChangeState(x + 1, y, ChessSquare.SquareState.Range))
        {
            squares.Add(board.Squares[x + 1, y]);
        }
        if (board.action.ChangeState(x + 1, y + 1, ChessSquare.SquareState.Range))
        {
            squares.Add(board.Squares[x + 1, y + 1]);
        }
        if (board.action.ChangeState(x + 2, y - 2, ChessSquare.SquareState.Range))
        {
            squares.Add(board.Squares[x + 2, y - 2]);
        }
        if (board.action.ChangeState(x + 2, y, ChessSquare.SquareState.Range))
        {
            squares.Add(board.Squares[x + 2, y]);
        }
        if (board.action.ChangeState(x + 2, y + 2, ChessSquare.SquareState.Range))
        {
            squares.Add(board.Squares[x + 2, y + 2]);
        }
    }
    public override void Use()
    {
        base.Use();

        for (int i = 0; i < squares.Count; i++)
        {
            targetPiece = squares[i].piece;
            AddTarget();            
        }

        for(int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];

            if (Attack(120))
            {
                Collection cl = cr.GetComponent<Collection>();

                if (cl.count < 10)
                    cl.count++;
            }
        }
        squares.Clear();
    }
}
