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
        for (int i = y - 1; i <= y + 1; i++)
        {
            if (!(0 <= i && i < 8)) continue;

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

            Frality fr = status.frality;
            AddBuff(fr, 2);
            
            if (Attack(120)) isUsed = true;
        }

        if (0 < x && board.Squares[x - 1, y].piece == null && isUsed)
        {
            StartCoroutine(cr.GetComponent<ChessPiece>().StartMove(x - 1, y));
        }
    }
    public override IEnumerator ShowEffect()
    {
        GameObject obj = Instantiate(effect, cr.transform.position, effect.transform.rotation);
        
        yield return null;
    }
}
