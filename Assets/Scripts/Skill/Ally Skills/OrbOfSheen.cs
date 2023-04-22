using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbOfSheen : Skill
{
    public override void Ready()
    {
        base.Ready();

        for(int i = x + 1; i <= x + 4; i++)
        {
            board.action.ChangeState(i, y, ChessSquare.SquareState.Attack);
        }
        
        for(int i = y - 1; i <= y + 1; i++)
        {
            board.action.ChangeState(x + 3, i, ChessSquare.SquareState.Attack);
        }
    }

    public override void Use()
    {
        base.Use();

        Weakness wk = gameObject.AddComponent<Weakness>();
        AddBuff(wk, 1);
        Destroy(wk);

        Attack(80);


    }
}
