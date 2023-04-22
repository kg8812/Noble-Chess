using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : EnemyChessPiece
{  
    public override bool CheckSkillAfterMove()
    {
        if (!base.CheckSkillAfterMove()) return false;

        int x = square.index1;
        int y = square.index2;

        if (x > 0 && board.Squares[x - 1, y].piece == null)
        {
            if (enemy.curSkill.CheckTargets(board.Squares[x - 1, y]))
                AddMoveList(x - 1, y);
        }

        return mList.Count > 0;
    }

    public override void CheckMoves()
    {
        base.CheckMoves();

        int x = square.index1;
        int y = square.index2;

        if (isFirstMove)
        {
            if (AddMoveList(x - 1, y))
            {
                AddMoveList(x - 2, y);
            }
        }
        else
        {
            AddMoveList(x - 1, y);

        }     
    }
}
