using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ChessSquare : MonoBehaviour
{
    public enum SquareState
    {
        Normal = 0, // 노말
        Move,   // 이동
        Attack, // 공격
        Buff, // 버프
        Place, // 설치
        Select, // 선택됨
        Range // 범위
    }
    public SquareState State = SquareState.Normal;

    public bool isWhite; // 백, 흑 칸 구분
    SpriteRenderer mat; // 색변경용 렌더러
    public int index1; // 첫번째 인덱스
    public int index2; // 두번째 인덱스

    public ChessPiece piece;    // 칸에 위치한 기물

    [SerializeField]
    private Sprite white;   // 백칸 이미지
    [SerializeField]
    private Sprite black;   // 흑칸 이미지
    public SpriteRenderer tecticalImage; // 기물 이미지 렌더러

    IEnumerator ReserveSkill() // 스킬 예약 함수
    {
        ChessPiece selected = ChessBoard.Instance.selected?.piece;
        Skill skill = TurnManager.Instance.selectedSkill;

        skill.targetSquare = this;
        skill.targetPiece = piece;

        if (skill.isImmediate)
        {

            if (!skill.isTwice)
            {
                ChessBoard.Instance.Cancel();
                ChessBoard.Instance.ColorReset();
            }

            StartCoroutine(UIManager.Instance.SetSkillProduction(skill));
            yield return null;

            StartCoroutine(skill.ShowEffect());
            skill.Use();
        }
        else
        {
            selected.character.ReserveSkill();
        }

        if (!skill.isTwice)
        {
            ChessBoard.Instance.Cancel();
            ChessBoard.Instance.ColorReset();
        }
    }

    bool CheckSkillState()
    {
        Skill skill = TurnManager.Instance.selectedSkill;

        if (TurnManager.Instance.isSkillUsed)
        {
            UIManager.Instance.ShowText("이번턴에 스킬을 사용하였습니다.", Color.red);
            return false;
        }
        if (skill.cr.isSkillUsed)
        {
            UIManager.Instance.ShowText("이미 스킬을 사용하였습니다.", Color.red);
            return false;
        }
        if (skill.cr.GetComponent<Character>().isReserved)
        {
            UIManager.Instance.ShowText("이미 스킬을 예약하였습니다.", Color.red);
            return false;
        }
        if (skill.CurCD > 0)
        {
            UIManager.Instance.ShowText("스킬 쿨타임입니다.", Color.red);
            return false;
        }
        if (skill.GetComponent<DesireOfCollector>()!=null && skill.cr.GetComponent<Collection>().count<10)
        {
            UIManager.Instance.ShowText("수집품을 10개이상 모아야 합니다.", Color.red);
            return false;
        }
        return true;
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.isGameOver) return;

        ChessPiece selected = ChessBoard.Instance.selected?.piece;

        switch (State)
        {
            case SquareState.Move:
                selected.isFirstMove = false;
                StartCoroutine(selected.StartMove(index1, index2));
                TurnManager.Instance.isMoved = true;
                ChessBoard.Instance.Cancel();
                ChessBoard.Instance.ColorReset();
                break;

            case SquareState.Attack:

                if (!CheckSkillState()) break;

                if (piece == null || !piece.gameObject.CompareTag("Enemy"))
                {
                    UIManager.Instance.ShowText("적이 없습니다.", Color.red);
                    break;
                }

                StartCoroutine(ReserveSkill());
                break;

            case SquareState.Buff:

                if (!CheckSkillState()) break;

                if (piece == null || !piece.gameObject.CompareTag("Ally"))
                {
                    UIManager.Instance.ShowText("아군이 없습니다.", Color.red);
                    break;
                }

                StartCoroutine(ReserveSkill());

                break;

            case SquareState.Place:

                if (!CheckSkillState()) break;

                if (piece != null)
                {
                    UIManager.Instance.ShowText("기물이 있는곳에 할 수 없습니다.", Color.red);
                    break;
                }

                StartCoroutine(ReserveSkill());

                break;

            case SquareState.Range:

                if (!CheckSkillState()) break;

                StartCoroutine(ReserveSkill());

                break;
            default:
                piece?.Select();
                break;
        }


    }
    void Start()
    {
        mat = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ChangeColor();
    }

    public int GetDistToAlly()
    {
        int min = 100;
        ChessBoard board = ChessBoard.Instance;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((board.Squares[i, j].piece?.gameObject?.CompareTag("Ally")) ?? false)
                {
                    min = Mathf.Min(min, board.action.GetDistance(this, board.Squares[i, j]));
                }
            }
        }

        return min;
    }

    public void SetPiece(ChessPiece piece)
    {
        this.piece = piece;
        piece.square = this;
        tecticalImage.sprite = piece.tecticalImage;
    }

    public void Attack(float dmg, bool isAlly)
    {
        if (piece == null) return;

        if (piece.gameObject.CompareTag("Ally") || piece.gameObject.CompareTag("Enemy"))
        {
            if (piece.gameObject.CompareTag("Ally") != isAlly)
            {
                piece.GetComponent<IOnDamage>()?.OnHit(dmg);
            }
        }
    }

    public bool CheckAttackable(bool isAlly)
    {
        if (piece != null && (piece.TryGetComponent(out Character c) != isAlly))
            return true;

        return false;
    }
    void ChangeColor()
    {
        switch (State)
        {
            case SquareState.Normal:
                if (isWhite)
                {
                    mat.sprite = white;
                    mat.color = Color.white;
                }
                else
                {
                    mat.sprite = black;
                    mat.color = Color.white;
                }
                break;
            case SquareState.Move:
                mat.sprite = white;
                mat.color = Color.yellow;
                break;
            case SquareState.Attack:
            case SquareState.Buff:
            case SquareState.Place:
            case SquareState.Range:
                mat.sprite = white;
                mat.color = Color.red;
                break;
            case SquareState.Select:
                mat.sprite = white;
                mat.color = Color.green;
                break;
        }
    }
}
