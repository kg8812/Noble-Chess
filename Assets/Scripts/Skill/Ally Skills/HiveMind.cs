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

        for (int i = x + 1; i <= x + 2; i++)
        {
            if (!(0 <= i && i < 8)) continue;

            if (board.Squares[i, y].piece != null && board.Squares[i, y].piece.TryGetComponent(out Enemy enemy))
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

    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;

        for (int i = x + 1; i <= x + 2; i++)
        {
            if (!(0 <= i && i < 8)) continue;

            if (board.Squares[i, y].piece !=null && board.Squares[i,y].piece.TryGetComponent(out Enemy enemy))
            {
                targetPiece = board.Squares[i, y].piece;
                AddTarget();
            }
        }

        for (int i = 0; i < targetList.Count; i++)
        {
            if (targetList[i] == null) continue;
            GameObject obj = Instantiate(effect, targetList[i].transform);
            obj.transform.position = targetList[i].transform.position;
            Destroy(obj, clip.length);
        }

        yield return new WaitForSeconds(clip.length);
        
    }
}
