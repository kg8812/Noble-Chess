using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrayOfFox : Skill
{
    public override void Ready()
    {
        base.Ready();

        for (int i = x + 1; i < 8; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Attack);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        Attack(110);
        cr.GetComponent<BulletBuff>().count++;
    }

    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;
        if (targetPiece == null) yield break;

        GameObject obj = Instantiate(effect, cr.transform);
        obj.transform.position = targetPiece.transform.position;
        yield return new WaitForSeconds(clip.length);
        Destroy(obj);
    }
}
