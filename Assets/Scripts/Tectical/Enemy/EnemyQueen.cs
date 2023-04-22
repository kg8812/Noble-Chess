using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueen : EnemyChessPiece
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

            if (enemy.curSkill.CheckTargets(i, j))
            {
                AddMoveList(i, j);
            }
        }

        for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            if (enemy.curSkill.CheckTargets(i, j))
            {
                AddMoveList(i, j);
            }
        }

        for (int i = x + 1, j = y - 1; i < 8 && j >= 0; i++, j--)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            if (enemy.curSkill.CheckTargets(i, j))
            {
                AddMoveList(i, j);
            }
        }

        for (int i = x - 1, j = y + 1; i >= 0 && j < 8; i--, j++)
        {
            if (board.Squares[i, j].piece != null)
            {
                break;
            }

            if (enemy.curSkill.CheckTargets(i, j))
            {
                AddMoveList(i, j);
            }
        }

        for (int i = x + 1; i < 8; i++)
        {
            if (board.Squares[i, y].piece != null)
                break;

            if (enemy.curSkill.CheckTargets(i, y))
            {
                AddMoveList(i, y);
            }
        }

        for (int i = x - 1; i >= 0; i--)
        {
            if (board.Squares[i, y].piece != null)
                break;

            if (enemy.curSkill.CheckTargets(i, y))
            {
                AddMoveList(i, y);
            }
        }

        for (int i = square.index2 + 1; i < 8; i++)
        {
            if (board.Squares[x, i].piece != null)
                break;

            if (enemy.curSkill.CheckTargets(x, i))
            {
                AddMoveList(x, i);
            }
        }

        for (int i = square.index2 - 1; i >= 0; i--)
        {
            if (board.Squares[x, i].piece != null)
                break;

            if (enemy.curSkill.CheckTargets(x, i))
            {
                AddMoveList(x, i);
            }
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

        for (int i = x + 1; i < 8; i++)
        {
            if (board.Squares[i, y].piece != null)
                break;

            AddMoveList(i, y);
        }

        for (int i = x - 1; i >= 0; i--)
        {
            if (board.Squares[i, y].piece != null)
                break;

            AddMoveList(i, y);
        }

        for (int i = square.index2 + 1; i < 8; i++)
        {
            if (board.Squares[x, i].piece != null)
                break;

            AddMoveList(x, i);
        }

        for (int i = square.index2 - 1; i >= 0; i--)
        {
            if (board.Squares[x, i].piece != null)
                break;

            AddMoveList(x, i);
        }
    }
}
