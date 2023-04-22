using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilOfMercy : Skill
{
    public override void Ready()
    {
        base.Ready();

        for(int i = x + 1; i < 8; i++)
        {
            board.action.ChangeState(i, y, ChessSquare.SquareState.Attack);
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
}
