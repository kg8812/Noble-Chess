using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public abstract class EnemyChessPiece : ChessPiece,IOnNewTurn
{
    public int mIdx1 { get; private set; } = -1; // 이동할 인덱스 1
    public int mIdx2 { get; private set; } = -1; // 이동할 인덱스 2

    public Enemy enemy { get { return GetComponent<Enemy>(); } } // Enemy 클래스
    public List<ChessSquare> mList { get; protected set; } = new List<ChessSquare>();

    protected override void Start()
    {
        base.Start();       
    }

    public void StartNewTurn()
    {
        mList.Clear();
        mIdx1 = -1;
        mIdx2 = -1;
    }
    public virtual bool CheckSkillAfterMove()
    {
        mList.Clear();
        if (enemy.curSkill == null) return false;

        return true;
    }
    public virtual int GetShortestMove()
    {
        int min = 100;

        for (int i = 0; i < mList.Count; i++)
        {
            if (min > mList[i].GetDistToAlly())
            {
                min = mList[i].GetDistToAlly();
                mIdx1 = mList[i].index1;
                mIdx2 = mList[i].index2;
            }
        }       

        return min;
    }

    public virtual void CheckMoves()
    {
        mList.Clear();
    }
    protected bool AddMoveList(int a, int b)
    {
        if (0 <= a && a < 8 && 0 <= b && b < 8 && board.Squares[a, b].piece == null)
        {
            mList.Add(board.Squares[a, b]);
            return true;
        }

        return false;
    }
}
