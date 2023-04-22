using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Violency : Skill
{
    public override void Ready()
    {
        base.Ready();
        
        for(int i = x + 1; i <= x + 2; i++)
        {
            for(int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Range);
            }
        }
    }

    public override void Use()
    {
        base.Use();
        x = board.selected.index1;
        y = board.selected.index2;

        for (int i = x + 1; i <= x + 2 && 0 <= i && i < 8; i++) 
        {
            for (int j = y - 1; j <= y + 1 && 0 <= j && j < 8; j++) 
            {
                targetPiece = board.Squares[i, j].piece;
                AddTarget();                
            }
        }

        for(int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];
            if (Attack(110))
            {
                cr.GetComponent<FoxFireStack>().count += 2;
            }
        }
    }
}
