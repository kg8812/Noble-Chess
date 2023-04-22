using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonRoute : Skill
{
    public override void Ready()
    {
        base.Ready();

        for (int i = y - 1; i <= y + 1; i++)
        {
            board.action.ChangeState(x + 1, i, ChessSquare.SquareState.Range);
        }
    }

    public override void Use()
    {
        base.Use();
        bool isUsed = false;
        for (int i = y - 1; i <= y + 1 && 0 <= i && i < 8; i++)
        {
            targetPiece = board.Squares[x + 1, i].piece;
            if (targetPiece?.GetComponent<Enemy>() != null)
            {
                AddTarget();

            }
        }

        for (int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];

            if (targetPiece.GetComponent<RBlood>() == null)
            {
                targetPiece.gameObject.AddComponent<RBlood>();
            }

            Frality fr = gameObject.AddComponent<Frality>();
            AddBuff(fr, 2);
            Destroy(fr);

            if (Attack(120)) isUsed = true;
        }

        if (0 < x && board.Squares[x - 1, y].piece == null && isUsed)
        {
            cr.GetComponent<ChessPiece>().StartMove(x - 1, y);
        }
    }
}
