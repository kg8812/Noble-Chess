using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    protected ChessBoard board { get { return ChessBoard.Instance; } }
    [Header("건드리기 X")]
    
    public ChessSquare square;    // 현재 위치한 칸
    public Character character; // 현재 캐릭터
    
    public bool isMovable = false;

    public int width = 1;
    public int height = 1;
    public int pos1;
    public int pos2;

    

    [Header("점프 높이(높을수록 낮게 뜀)")]
    public float jumpHeight = 3;
    [Header("이동속도")]
    public float moveSpeed = 1;

    public bool isFirstMove = true;
    public Sprite tecticalImage;

    private void Awake()
    {
        TryGetComponent(out character);      
       
    }
    protected virtual void Start()
    {
        isFirstMove = true;
        transform.localScale *= Math.Min(width, height);
    }

    
    public void Select() // 기물 선택
    {
        if (!GameManager.Instance.isPlayerTurn) return;

        board.Cancel();
        board.ColorReset();
        board.selected = square;
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if (board.Squares[i,j].piece == board.selected.piece)
                {
                    board.Squares[i, j].State = ChessSquare.SquareState.Select;
                }
            }
        }
        //board.selected.State = ChessSquare.SquareState.Select;        

        if (board.selected.piece.CompareTag("Enemy"))
        {
            UIManager.Instance.enemyStatus.SetActive(true);
        }
        else if(board.selected.piece.CompareTag("Ally"))
        {
            UIManager.Instance.behaviourOption.SetActive(true);
        }
    }

    public virtual void MoveReady() //이동 준비 
    {
        board.ColorReset();
    }

    public IEnumerator StartMove(int i, int j) // 이동 시작
    {       
        square.piece = null;
        square = board.Squares[i, j];
        square.piece = this;
        
        pos1 = i;
        pos2 = j;
        board.Cancel();
        board.ColorReset();
        yield return StartCoroutine(Move());
    }

    public IEnumerator StartMove(ChessSquare sq)
    {
        int i = sq.index1;
        int j = sq.index2;
        
        square.piece = null;
        square = board.Squares[i, j];
        square.piece = this;      

        pos1 = i;
        pos2 = j;
        board.Cancel();
        board.ColorReset();
        yield return StartCoroutine(Move());
    }

    public IEnumerator Move() // 이동 코루틴 함수
    {
        float slerpTime = 0;
        Vector3 startPos = transform.position;
        Vector3 endPos = square.transform.position;

        float moveTime = (Vector3.Distance(startPos, endPos) / 20 + 0.5f) / moveSpeed;


        while (slerpTime < moveTime)
        {
            slerpTime += Time.deltaTime;
            Vector3 center = (startPos + endPos) * 0.5f;
            center.y -= jumpHeight;
            Vector3 start = startPos - center;
            Vector3 end = endPos - center;
            transform.position = Vector3.Slerp(start, end, slerpTime / moveTime);
            transform.position += center;
            yield return new WaitForEndOfFrame();
        }                      
    }

    protected virtual void OnDestroy()
    {
        try
        {
            if (board == null) return;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board.Squares[i, j].piece == this)
                    {                      
                        board.Squares[i, j].piece = null;
                    }
                }
            }

            board.ally.Remove(this);
            board.enemy.Remove(this);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }
}
