using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabbing : Skill
{
    public override void Ready()
    {
        base.Ready();

        for(int i = y - 1; i <= y + 1; i++)
        {
            board.action.ChangeState(x + 2, i, ChessSquare.SquareState.Attack);
        }
    }
    public override void Use()
    {
        base.Use();

        int x = targetSquare.index1;
        int y = targetSquare.index2;

        if (board.Squares[x - 1, y].piece == null)
        {
            cr.GetComponent<ChessPiece>().StartMove(x - 1, y);
        }

        Attack(100);
    }
}
