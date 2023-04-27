using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuff : Buff,IOnDmgBuff
{   

    private void OnEnable()
    {
        statusName = "탄환";
        description = "스택마다 공격력이 5% 증가한다";
    }
    public float GetBuff(float dmg)
    {
        return dmg * 0.05f * count;
    }

    public override void EndTurn()
    {
        
    }
}
