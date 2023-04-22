using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveMind : Skill
{
    public override void Ready()
    {
        base.Ready();

        board.action.ChangeState(x + 1, y, ChessSquare.SquareState.Range);
        board.action.ChangeState(x + 2, y, ChessSquare.SquareState.Range);
    }

    public override void Use()
    {
        base.Use();
        Snare sn = gameObject.AddComponent<Snare>();

        for (int i = x + 1; i <= x + 2 && 0 <= i && i < 8; i++)
        {
            if (board.Squares[i, y].piece.GetComponent<Enemy>())
            {
                targetPiece = board.Squares[i, y].piece;
                AddTarget();
            }
        }
        for (int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];
            AddBuff(sn, 1);
        }
        Destroy(sn);

    }
}
