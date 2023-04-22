using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using System;

public class ChessBoard : Singleton<ChessBoard>
{
    [SerializeField] GameObject square;    // 체스칸 프리팹
    public ChessSquare[,] Squares { get; private set; } = new ChessSquare[8, 8];    // 체스칸 배열
    public ChessSquare selected;    // 현재 선택된 칸

    public List<ChessPiece> ally { get; private set; } = new List<ChessPiece>();    // 아군 기물들
    public List<ChessPiece> enemy { get; private set; } = new List<ChessPiece>();   // 적 기물들   

    public ChessAction action { get; private set; }

    public void Create()
    {
        action = GetComponent<ChessAction>();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Squares[i, j] = Instantiate(square, transform).GetComponent<ChessSquare>();
                Squares[i, j].transform.localPosition = new Vector3(j, 0, i);
                Squares[i, j].transform.localScale = Vector3.one;
                Squares[i, j].name = $"squares({i * 8 + j})";
                Squares[i, j].index1 = i;
                Squares[i, j].index2 = j;

                if ((i + j) % 2 == 0)
                {
                    Squares[i, j].isWhite = false;
                }
                else
                {
                    Squares[i, j].isWhite = true;
                }
            }
        }

        PieceFactory.Instance.CreatePieces(ally, true);
        PieceFactory.Instance.CreatePieces(enemy, false);

        SetPosition(ally);
        SetPosition(enemy);

    }

    void SetPosition(List<ChessPiece> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            SetPosition(list[i]);
        }
    }

    public void SetPosition(ChessPiece piece)
    {
        int x = piece.pos1;
        int y = piece.pos2;
        int w = piece.width;
        int h = piece.height;

        Vector3 pos = Vector3.zero;

        for (int j = x; j > x - h; j--)
        {
            for (int k = y; k < y + w; k++)
            {
                Squares[j, k].SetPiece(piece);
                pos += Squares[j, k].transform.position;
            }         
        }

        pos /= w * h;

        piece.transform.position = pos;
    }

    public ChessPiece Replace(ChessPiece c1, ChessPiece c2)
    {
        bool isFound = false;
        c2 = Instantiate(c2, GameObject.Find("Characters").transform);

        for (int i = 0; i < ally.Count; i++)
        {
            if (ally[i].GetComponent<Creature>().Name == c1.GetComponent<Creature>().Name)
            {
                ally[i] = c2;
                c2.pos1 = c1.pos1;
                c2.pos2 = c1.pos2;

                SetPosition(c2);
                isFound = true;
                break;
            }
        }

        for (int i = 0; i < enemy.Count; i++)
        {
            if (enemy[i].GetComponent<Creature>().Name == c1.GetComponent<Creature>().Name)
            {
                enemy[i] = c2;
                c2.pos1 = c1.pos1;
                c2.pos2 = c1.pos2;

                SetPosition(c2);
                isFound = true;
                break;
            }
        }

        if (isFound)
        {
            CamManager.Instance.ResetCam();
            IOnNewTurn[] nt = c2.GetComponents<IOnNewTurn>();

            for(int i=0; i < nt.Length; i++)
            {
                nt[i].StartNewTurn();
            }            

            Destroy(c1.gameObject);
            return c2;

        }
        else
        {
            Destroy(c2.gameObject);
            return null;
        }
    }
    public void ChangeCam(bool is2D)
    {
        for (int i = 0; i < ally.Count; i++)
        {
            ally[i].GetComponent<Creature>().ChangeImage(is2D);
        }

        for (int i = 0; i < enemy.Count; i++)
        {
            enemy[i].GetComponent<Creature>().ChangeImage(is2D);
        }
    }
    public void ColorReset()
    {

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (Squares[i, j].State != ChessSquare.SquareState.Select)
                {
                    Squares[i, j].State = ChessSquare.SquareState.Normal;
                }
                
            }
        }

    }

    public void Cancel()
    {
        if (selected != null)
        {
            selected.State = ChessSquare.SquareState.Normal;
        }

        selected = null;
        UIManager.Instance.behaviourOption.SetActive(false);
    }
}
