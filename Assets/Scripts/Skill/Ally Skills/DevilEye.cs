using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilEye : Skill
{
    
    public override void Ready()
    {
        base.Ready();

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Attack);
            }
        }
    }

    public override void Use()
    {
        base.Use();        

        if (targetPiece.gameObject.GetComponent<RBlood>() == null)
        {
            targetPiece.gameObject.AddComponent<RBlood>();
        }

        Attack(130);
    }

    public override IEnumerator ShowEffect()
    {
        GameObject obj = Instantiate(effect);
        obj.transform.position = cr.transform.position;
        ReadyEffect ready = obj.GetComponent<ReadyEffect>();
        ready.bullet.target = targetPiece;
        yield return new WaitForSeconds(clip.length);
        ready.Fire();
        Destroy(obj);
    }
}
