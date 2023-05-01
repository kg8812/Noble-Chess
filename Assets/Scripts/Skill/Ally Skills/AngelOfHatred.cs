using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngelOfHatred : Skill
{
    public AnimationClip clip;

    public override void Ready()
    {
        base.Ready();

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Range);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                targetPiece = board.Squares[i, j].piece;

                if (targetPiece?.GetComponent<RBlood>() != null)
                {
                    Destroy(targetPiece.GetComponent<RBlood>());
                    AddTarget();               
                }
            }
        }

        for (int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];
            Attack(360);
        }
    }

    public override IEnumerator ShowEffect()
    {
        GameObject obj = Instantiate(effect);
        effect.transform.position = board.transform.position + new Vector3(5, 0, 5);
        yield return new WaitForSeconds(clip.length);
        Destroy(obj);
    }
}
