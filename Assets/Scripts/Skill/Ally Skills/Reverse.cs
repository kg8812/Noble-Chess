using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : Skill
{
    public override void Use()
    {
        base.Use();
        board.action.Swap(cr.GetComponent<ChessPiece>().square, targetSquare);

        Amplification amp = gameObject.AddComponent<Amplification>();
        AddBuff(amp, 3);
        Destroy(amp);       
    }

    public override void Ready()
    {
        base.Ready();

        for(int i = x - 1; i <= x + 1; i++)
        {
            for(int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Buff);
            }
        }
    }

    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;

        GameObject obj = Instantiate(effect, cr.transform);
        GameObject obj2 = Instantiate(effect, targetPiece.transform);
        obj.transform.position = cr.transform.position;
        obj2.transform.position = targetPiece.transform.position;
        yield return new WaitForEndOfFrame();
        Destroy(obj,clip.length);
        Destroy(obj2,clip.length);
    }
}
