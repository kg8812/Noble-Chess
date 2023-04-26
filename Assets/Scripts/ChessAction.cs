using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessAction : MonoBehaviour
{
    ChessSquare[,] Squares { get { return ChessBoard.Instance.Squares; } }
   
    public delegate bool check(int a, int b, bool isAlly); // 체크 델리게이트

    public void ActionInRange(int range, int index1, int index2, ChessSquare.SquareState state)
    {
        int x1 = index1 - range;
        int y1 = index2 - range;
        int x2 = index1 + range;
        int y2 = index2 + range;

        for (int i = x1; i <= x2; i++)
        {
            if (i < 0 || 8 <= i) continue;

            for (int j = y1; j <= y2; j++)
            {
                if (i == index1 && j == index2) continue;
                if (j < 0 || 8 <= j) continue;
                ChangeState(i, j, state);
            }
        }
    }

    public void Swap(ChessSquare a,ChessSquare b)
    {
        ChessPiece temp = a.piece;
        a.SetPiece(b.piece);
        b.SetPiece(temp);

        a.piece.pos1 = b.index1;
        a.piece.pos2 = b.index2;
        b.piece.pos1 = a.index1;
        b.piece.pos2 = a.index2;

        StartCoroutine(a.piece.Move());
        StartCoroutine(b.piece.Move());
    }
    public List<ChessSquare> CheckInRange(int range, int index1, int index2, bool isAlly, check check)
    {
        int x1 = index1 - range;
        int y1 = index2 - range;
        int x2 = index1 + range;
        int y2 = index2 + range;
        List<ChessSquare> list = new List<ChessSquare>();

        for (int i = x1; i <= x2; i++)
        {
            if (!(0 <= i && i < 8)) continue;
            for (int j = y1; j <= y2 && 0 <= j && j < 8; j++)
            {
                if (i == index1 && j == index2) continue;
                if (!(0 <= j && j < 8)) continue;

                if (check(i, j, isAlly)) list.Add(Squares[i, j]);
            }
        }
        return list;
    }
    public bool ChangeState(int a, int b,ChessSquare.SquareState state)
    {
        if (0 <= a && a < 8 && 0 <= b && b < 8)
        {            
            if (state == ChessSquare.SquareState.Move && Squares[a, b].piece != null) 
            {
                return false;
            }
            Squares[a, b].State = state;
            return true;
        }
        return false;
    }
    
    public bool CheckMovable(int a, int b)
    {
        return 0 <= a && a < 8 && 0 <= b && b < 8 && Squares[a, b].piece == null;
    }
    public bool CheckAttackable(int a, int b, bool isAlly)
    {
        if (0 <= a && a < 8 && 0 <= b && b < 8)
        {
            return Squares[a, b].CheckAttackable(isAlly);
        }
        return false;
    }

    public ChessPiece AddPiece(int a, int b, string pName, bool isAlly)
    {
        if (!(0 <= a && a < 8 && 0 <= b && b < 8 && Squares[a, b].piece == null))
            return null;

        ChessPiece cp = PieceFactory.Instance.Create(pName);
        Debug.Log(cp.name);
        if (cp != null)
        {
            Squares[a, b].SetPiece(cp);
            cp.pos1 = a;
            cp.pos2 = b;
            cp.transform.position = Squares[a, b].transform.position;
            if (isAlly)
            {
                ChessBoard.Instance.ally.Add(cp);
            }
            else
            {
                ChessBoard.Instance.enemy.Add(cp);
            }
            CamManager.Instance.ResetCam();

            IOnNewTurn[] nt = cp.GetComponents<IOnNewTurn>();

            for (int i = 0; i < nt.Length; i++)
            {
                nt[i].StartNewTurn();
            }
        }

        return cp;
    }
    public int GetDistance(ChessSquare s1, ChessSquare s2)
    {
        int i1 = s1.index1;
        int i2 = s2.index1;

        int j1 = s1.index2;
        int j2 = s2.index2;

        int i = Mathf.Abs(i1 - i2);
        int j = Mathf.Abs(j1 - j2);

        int result = i + j;
        if (i == j) result /= 2;

        return result;
    }
}
