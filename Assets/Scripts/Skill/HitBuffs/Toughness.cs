using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toughness : Buff, IOnDmgBuff
{
    private void Start()
    {
        statusName = "강인함";
        description = "받는 데미지가 10% 감소한다";
        image = sm.toughness.image;
    }
    public float GetBuff(float dmg)
    {
        return dmg * 0.1f;
    }
}
