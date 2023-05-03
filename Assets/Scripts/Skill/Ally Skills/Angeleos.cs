using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angeleos : Skill
{
    public override void Ready()
    {
        base.Ready();

        for (int i = 4; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Range);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        for (int i = 4; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                targetPiece = board.Squares[i, j].piece;
                if (targetPiece == null) continue;

                AddTarget();
            }
        }
        
        for (int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];

            if (targetList[i].CompareTag("Ally"))
            {                
                Revival rv = status.revival;               
                AddBuff(rv, 2);                
            }
            else if (targetList[i].CompareTag("Enemy"))
            {                
                Snare sn = status.snare;
                AddBuff(sn, 2);               
            }
        }
    }
}
