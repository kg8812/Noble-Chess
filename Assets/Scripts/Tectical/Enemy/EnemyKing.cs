using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKing : EnemyChessPiece
{
    public override bool CheckSkillAfterMove()
    {
        if (!base.CheckSkillAfterMove()) return false;

        int x = square.index1;
        int y = square.index2;

        for (int i = x - 1; 0 <= i && i <= x + 1 && i < 8; i++)
        {
            for (int j = y - 1; 0 <= j && j <= y + 1 && j < 8; j++)
            {
                if (i == x && j == y || board.Squares[i, j].piece != null) continue;

                if (enemy.curSkill.CheckTargets(square))
                    AddMoveList(i, j);
            }
        }

        return mList.Count > 0;
    }

    public override void CheckMoves()
    {
        base.CheckMoves();

        int x = square.index1;
        int y = square.index2;

        for (int i = x - 1; 0 <= i && i <= x + 1 && i < 8; i++)
        {
            for (int j = y - 1; 0 <= j && j <= y + 1 && j < 8; j++)
            {
                if (i == x && j == y || board.Squares[i, j].piece != null) continue;

                AddMoveList(i, j);
            }
        }
    }
}
