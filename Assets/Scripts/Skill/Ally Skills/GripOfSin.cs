using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripOfSin : Skill
{
    public override void Ready()
    {
        base.Ready();
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Place);
            }
        }
    }

    public override void Use()
    {
        base.Use();
        x = targetSquare.index1;
        y = targetSquare.index2;
        ChessPiece piece = cr.GetComponent<ChessPiece>();

        StartCoroutine(piece.StartMove(targetSquare));
        Amplification amp = gameObject.AddComponent<Amplification>();

        for (int i = x - 1; i <= x + 1; i++)
        {
            if (!(0 <= i && i < 8)) continue;

            for (int j = y - 1; j <= y + 1; j++)
            {
                if (!(0 <= j && j < 8)) continue;

                if (board.Squares[i, j].piece!=null && board.Squares[i,j].piece.CompareTag("Ally"))
                {
                    targetPiece = board.Squares[i, j].piece;
                    AddTarget();                          
                }
            }
        }

        for(int i=0;i< targetList.Count;i++)
        {
            targetPiece = targetList[i];
            AddBuff(amp, 3);
        }
        Destroy(amp);
    }

    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;
        
        GameObject obj = Instantiate(effect, cr.transform);
        obj.transform.position = cr.transform.position;
        obj.transform.localPosition = new Vector3(0, 0, -0.5f);

        yield return new WaitForSeconds(clip.length);
        Destroy(obj);        
    }
}
