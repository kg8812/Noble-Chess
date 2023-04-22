using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBishop : EnemyChessPiece
{
    public override bool CheckSkillAfterMove()
    {
        if (!base.CheckSkillAfterMove()) return false;

        int x = square.index1;
        int y = square.index2;

        for (int i = x + 1, j = y + 1; i < 8 && j < 8; i++, j++)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            if (enemy.curSkill.CheckTargets(board.Squares[i, j]))
                AddMoveList(i, j);
        }

        for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            if (enemy.curSkill.CheckTargets(board.Squares[i, j]))
                AddMoveList(i, j);
        }

        for (int i = x + 1, j = y - 1; i < 8 && j >= 0; i++, j--)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            if (enemy.curSkill.CheckTargets(board.Squares[i, j]))
                AddMoveList(i, j);
        }

        for (int i = x - 1, j = y + 1; i >= 0 && j < 8; i--, j++)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            if (enemy.curSkill.CheckTargets(board.Squares[i, j]))
                AddMoveList(i, j);
        }

        return mList.Count > 0;
    }

    public override void CheckMoves()
    {
        base.CheckMoves();

        int x = square.index1;
        int y = square.index2;

        for (int i = x + 1, j = y + 1; i < 8 && j < 8; i++, j++)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }        
                AddMoveList(i, j);
        }

        for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }          
                AddMoveList(i, j);
        }

        for (int i = x + 1, j = y - 1; i < 8 && j >= 0; i++, j--)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }          
                AddMoveList(i, j);
        }

        for (int i = x - 1, j = y + 1; i >= 0 && j < 8; i--, j++)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }           
                AddMoveList(i, j);
        }
    }
}
