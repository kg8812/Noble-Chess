using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfHeal : Skill
{
    public override void Ready()
    {
        base.Ready();

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Range);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        x = targetSquare.index1;
        y = targetSquare.index2;

        for(int i = x - 1; i <= x + 1; i++)
        {
            if (!(0 <= i && i < 8)) continue;

            for (int j = y - 1; j <= y + 1; j++)
            {
                if (!(0 <= j && j < 8)) continue;

                targetPiece = board.Squares[i, j].piece;

                AddTarget();
                
            }
        }

        for(int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];

            if (targetPiece != null)
            {
                float amount = targetPiece.GetComponent<Creature>().MaxHp * 0.2f;
                Heal(amount);
            }
        }
    }
}
