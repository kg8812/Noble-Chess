using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RingOfBonding : Skill
{ 
    ChessPiece target;
    bool isFirst = true;
    public GameObject effect2;
    public AnimationClip clip2;

    public override void Ready()
    {
        base.Ready();

        isTwice = true;
        isFirst = true;
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Buff);
            }
        }
    }

    public override void Use()
    {       
        if (isFirst)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    board.action.ChangeState(i, j, ChessSquare.SquareState.Place);
                }
            }            
            target = targetPiece;
            isFirst = false;
        }
        else if (!isFirst)
        {
            base.Use();
            StartCoroutine(ShowEffect2());
            isTwice = false;
            isFirst = true;            
        }
    }

    IEnumerator ShowEffect2()
    {            
        yield return StartCoroutine(target.StartMove(targetSquare));
        Debug.Log(target);
        GameObject obj = Instantiate(effect2, target.transform);
        obj.transform.position = target.transform.position - new Vector3(0,0,0.5f);
        target = null;
        yield return new WaitForSeconds(clip2.length);
        Destroy(obj);
    }
    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;
        if (target == null) yield break;
        if (!isFirst)
        {
            GameObject obj = Instantiate(effect, target.transform);
            obj.transform.position = target.transform.position;
            yield return new WaitForSeconds(clip.length);
            Destroy(obj);
        }        
    }
}
