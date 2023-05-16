using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstBullet : Skill
{
    public bool isEnhance = false;
   
    public override void Ready()
    {
        base.Ready();

        board.action.ChangeState(x + 1, y - 1, ChessSquare.SquareState.Attack);
        board.action.ChangeState(x + 1, y + 1, ChessSquare.SquareState.Attack);
    }

    public override void Use()
    {
        base.Use();

        float dmg = 130;
        if (isEnhance) dmg += 20;

        Attack(dmg);

        targetPiece = cr.GetComponent<ChessPiece>();

        AddBarrier(cr.Atk * 0.15f);

        isEnhance = false;
    }

    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;
        if (cr == null) yield break;

        GameObject obj = Instantiate(effect, cr.transform);
        obj.transform.position = cr.transform.position;
        obj.transform.position += new Vector3(1.5f, 0, 1);
        yield return new WaitForSeconds(clip.length);
        Destroy(obj);
    }
}
