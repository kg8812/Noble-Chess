using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awakening : EnemySkill
{
    public ChessPiece obj;
    public bool isHpRegen;

    public override bool CheckTargets()
    {
        if (GameObject.Find("Boss2"))        
            return true;
        

        return false;
    }

    public override bool CheckTargets(ChessSquare square)
    {
        if (GameObject.Find("Boss2"))
            return true;

        return false;
    }

    public override bool CheckTargets(int idx1, int idx2)
    {
        if (GameObject.Find("Boss2"))
            return true;

        return false;
    }

    public override void Use()
    {
        base.Use();
        Creature c = board.Replace(square.piece, obj).GetComponent<Creature>();

        if (!isHpRegen)
        {
            float perc = enemy.CurHp / enemy.MaxHp;

            c.CurHp *= perc;
        }

    }

    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;
        if (cr == null) yield break;
        GameObject obj = Instantiate(effect);
        obj.transform.position = cr.transform.position;        
        Destroy(obj,clip.length);
    }
}
