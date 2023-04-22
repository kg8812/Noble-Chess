using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sins : Skill
{
    public override void Ready()
    {
        base.Ready();

        board.action.ChangeState(x + 1, y, ChessSquare.SquareState.Attack);
        board.action.ChangeState(x + 2, y, ChessSquare.SquareState.Attack);
    }

    public override void Use()
    {
        base.Use();

        Attack(100);
    }
}
