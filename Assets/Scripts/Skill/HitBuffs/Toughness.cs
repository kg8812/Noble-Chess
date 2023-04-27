using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toughness : Buff, IOnDmgBuff
{
    private void OnEnable()
    {
        statusName = "강인함";
        description = "받는 데미지가 10% 감소한다";
    }
    public float GetBuff(float dmg)
    {
        return dmg * 0.1f;
    }
}
