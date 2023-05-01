using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected int x, y;
    [SerializeField]
    int startCD;
    [SerializeField]
    int normalCD;

    public ChessSquare targetSquare;
    public ChessPiece targetPiece;
    protected List<ChessPiece> targetList = new List<ChessPiece>();
    protected StatusManager status { get { return StatusManager.Instance; } }
    public bool isImmediate = false;
    public int StartCD { get { return startCD; } }
    public int NormalCD { get { return normalCD; } }
    public Creature cr;
    int curCD;
    public bool isSpecial = false;
    public bool isTwice = false;
    public int CurCD
    {
        get { return curCD; }
        set
        {
            if (value < 0) curCD = 0;
            else curCD = value;
        }
    }

    protected bool IsCD
    {
        get
        {
            if (CurCD > 0) return true;
            else return false;
        }
    }

    public bool isPassive;
    public Sprite skillImage;
    public string skillName;
    [TextArea]
    public string description;
    protected ChessBoard board
    {
        get { return ChessBoard.Instance; }
    }

    protected ChessSquare square
    {
        get { return cr.GetComponent<ChessPiece>().square; }
    }
    public GameObject effect;
    public AnimationClip clip;

    public virtual void Use()
    {      
        CurCD = NormalCD;
        cr.isSkillUsed = true;
        targetList.Clear();
    }   

    public virtual void Ready()
    {
        x = board.selected.index1;
        y = board.selected.index2;
        ChessBoard.Instance.ColorReset();
        TurnManager.Instance.selectedSkill = this;
    }

    protected void AddTarget()
    {
        if (targetPiece == null) return;

        if(!targetList.Contains(targetPiece))
            targetList.Add(targetPiece);
    }

    protected bool Attack(float ratio)
    {
        if (targetPiece?.GetComponent<Enemy>() != null)
        {
            cr.GetComponent<Character>().Attack(targetPiece.GetComponent<Enemy>(),ratio);
            return true;
        }
        return false;
    }
    protected void Heal(float amount)
    {
        if (targetPiece?.character != null)
        {
           targetPiece.character.CurHp += amount;
        }
    }

    protected void AddBuff(Buff buff,int count)
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

    protected void AddBarrier(float amount)
    {
        if (targetPiece?.GetComponent<Character>() == null)
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

    public virtual IEnumerator ShowEffect()
    {
        if (effect == null) yield break;

        GameObject obj = Instantiate(effect,cr.transform);
        obj.transform.position = cr.transform.position;
        yield return new WaitForSeconds(clip.length);
        Destroy(obj);
    }
   
}
