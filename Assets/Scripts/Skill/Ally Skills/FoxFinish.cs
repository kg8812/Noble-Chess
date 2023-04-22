using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxFinish : Skill
{
    public override void Ready()
    {
        base.Ready();

        board.action.ActionInRange(2, x, y, ChessSquare.SquareState.Range);
    }
    public override void Use()
    {
        base.Use();
        int count = cr.GetComponent<FoxFireStack>().count;

        float dmg = 100 + 50 * count;
        for (int i = x - 2; i <= x + 2 && 0 <= i && i < 8; i++)
        {
            for (int j = y - 2; j <= y + 2 && 0 <= j && j < 8; j++)
            {
                targetPiece = board.Squares[i, j].piece;
                AddTarget();
            }
        }

        for (int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];
            Attack(dmg);
        }
        cr.GetComponent<FoxFireStack>().count = 0;
    }
}
