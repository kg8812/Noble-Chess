using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodFreshGreen : Skill
{
    public override void Use()
    {
        base.Use();
        if (targetSquare?.piece?.character != null)
        {
            float amount = targetSquare.piece.character.MaxHp * 0.1f;
            Heal(amount);
        }
    }
    public override void Ready()
    {
        base.Ready();
        for(int i = x + 1; i <= x + 3; i++)
        {
            for(int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Buff);
            }
        }
    }
}
