using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilOfMercy : Skill
{  
    public AnimationClip clip;
    public override void Ready()
    {
        base.Ready();

        for(int i = x + 1; i < 8; i++)
        {
            board.action.ChangeState(i, y, ChessSquare.SquareState.Range);
        }
    }

    public override void Use()
    {
        base.Use();        

        for(int i = x + 1; i < 8; i++)
        {          
            targetPiece = board.Squares[i, y].piece;

            if (targetPiece?.GetComponent<Enemy>() != null)
            {
                AddTarget();                          
            }
        }

        for(int i=0;i<targetList.Count;i++)
        {
            targetPiece = targetList[i];
            targetList[i].gameObject.AddComponent<RBlood>();
            Attack(140);
        }
    }

    public override IEnumerator ShowEffect()
    {       
        GameObject ef = Instantiate(effect,cr.transform.position,effect.transform.rotation);
        
        ef.transform.position = (board.Squares[x + 1, y].transform.position + board.Squares[7, y].transform.position) / 2;
        ef.transform.position -= new Vector3(0.5f, 0, 0);
        ef.transform.localScale = new Vector3(1.2f * (7-x)/7, 1, 1);
        yield return new WaitForSeconds(clip.length);
        Destroy(ef);
    }
}
