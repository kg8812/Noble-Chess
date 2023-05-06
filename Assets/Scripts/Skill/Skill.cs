using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    // 스킬 부모 클래스
    // 스킬 사용, 사용 준비 (범위 표시), 타겟 추가, 공격, 힐, 버프, 배리어, 이펙트 기능 포함
    // 스킬 구현시 이 클래스를 상속받고 기본적으로 Ready (사용 준비),Use(사용) 함수를 오버라이딩해서 효과를 구현해야함

    protected int x, y;
    [SerializeField]
    int startCD; // 시작 쿨타임
    [SerializeField]
    int normalCD; // 기본 쿨타임

    public ChessSquare targetSquare; // 타겟 칸
    public ChessPiece targetPiece; // 타겟 기물
    protected List<ChessPiece> targetList = new List<ChessPiece>(); // 범위형일시 타겟 기물 목록
    protected StatusManager status { get { return StatusManager.Instance; } } // 상태이상 매니저
    public bool isImmediate = false; // 즉발형 여부
    public int StartCD { get { return startCD; } } // 시작 쿨타임 프로퍼티
    public int NormalCD { get { return normalCD; } } // 기본 쿨타임 프로퍼티
    public Creature cr; // 이 스킬의 주인
    int curCD; // 현재 쿨타임
    public bool isSpecial = false; // 특별 스킬 (체크시 특별 이펙트 활성화)
    public bool isTwice = false; // 클릭이 두번 필요한 스킬 (유대의 고리같이 아군을 이동시키는 스킬 등)

    public int CurCD // 현재 쿨타임 프로퍼티
    {
        get { return curCD; }
        set
        {
            if (value < 0) curCD = 0;
            else curCD = value;
        }
    }

    protected bool IsCD // 쿨타임 여부
    {
        get
        {
            if (CurCD > 0) return true;
            else return false;
        }
    }

    public bool isPassive; // 패시브 여부 (UI 표시용)
    public Sprite skillImage; // 스킬 이미지
    public string skillName; // 스킬 이름
    [TextArea]
    public string description; // 스킬 설명
    protected ChessBoard board // 체스판 인스턴스
    {
        get { return ChessBoard.Instance; }
    }

    protected ChessSquare square // 스킬주인이 현재 위치한 칸
    {
        get { return cr.GetComponent<ChessPiece>().square; }
    }
    public GameObject effect; // 이펙트
    public AnimationClip clip; // 이펙트 클립 (코루틴에서 길이 사용)

    public virtual void Use() // 스킬 사용 함수, 스킬마다 오버라이딩 및 베이스 필요
    {      
        CurCD = NormalCD;
        cr.isSkillUsed = true;
        targetList.Clear();
    }   

    public virtual void Ready() // 스킬 준비 함수, 스킬마다 오버라이딩 및 베이스 필요
    {
        x = board.selected.index1;
        y = board.selected.index2;
        ChessBoard.Instance.ColorReset();
        TurnManager.Instance.selectedSkill = this;
    }

    protected void AddTarget() // 타겟 추가 함수, 타겟 리스트에 타겟 추가
    {
        if (targetPiece == null) return;

        if(!targetList.Contains(targetPiece))
            targetList.Add(targetPiece);
    }

    protected bool Attack(float ratio) // 공격 함수, 공격전 타겟 선정 필요
    {
        if (targetPiece!=null && targetPiece.TryGetComponent(out Enemy enemy))
        {
            cr.GetComponent<Character>().Attack(targetPiece.GetComponent<Enemy>(),ratio);
            return true;
        }
        return false;
    }
    protected void Heal(float amount) // 힐 함수, 사용전 타겟 선정 필요
    {
        if (targetPiece?.character != null)
        {
           targetPiece.character.CurHp += amount;
        }
    }

    protected void AddBuff(Buff buff,int count) // 버프 함수, 사용전 타겟 선정 필요
    {
        if (targetPiece == null) return;
        
        Buff b = targetPiece.gameObject.GetComponent(buff.GetType()) as Buff;
        if (b != null)
        {
            b.count += count;
        }
        else
        {
            b = targetPiece.gameObject.AddComponent(buff.GetType()) as Buff;
            b.image = buff.image;
            b.count = count;
        }
    }

    protected void AddBarrier(float amount) // 배리어 함수, 사용전 타겟 선정 필요
    {
        if (targetPiece == null || !targetPiece.TryGetComponent(out Character cr))
            return;

        Barrier b = targetPiece.GetComponent<Barrier>();

        if (b==null)
        {
            b = targetPiece.gameObject.AddComponent<Barrier>();
            b.amount = amount;
        }
        else
        {
            b.amount += amount;
        }       
    }

    public virtual IEnumerator ShowEffect() // 이펙트 함수, 기본적으로 캐릭터 위치에 생성되며 위치 조절이 필요할시 오버라이딩 필요
    {
        if (effect == null) yield break;
        if (cr == null) yield break;
        GameObject obj = Instantiate(effect,cr.transform);
        obj.transform.position = cr.transform.position;
        yield return new WaitForSeconds(clip.length);
        Destroy(obj);
    }
   
}
