using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterFly : Skill
{
    public override void Use()
    {
        base.Use();
        float amount = cr.CurHp * 0.05f;
        Heal(amount);
    }
    public override void Ready()
    {
        base.Ready();

        for (int i = x + 1; i <= x + 3; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Buff);
            }
        }
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
