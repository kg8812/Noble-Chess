using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakness : Buff, IOnDmgBuff
{
    private void OnEnable()
    {
        statusName = "쇠약";
        description = "공격력이 10% 감소한다";
    }
    public float GetBuff(float dmg)
    {
        return -(dmg * 0.1f);
    }
}
