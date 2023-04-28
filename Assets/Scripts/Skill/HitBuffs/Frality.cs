using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frality : Buff, IOnHitBuff
{
    private void Start()
    {
        statusName = "취약";
        description = "받는 데미지가 5% 증가한다";
        image = sm.frality.image;
    }
    public float GetBuff(float dmg)
    {
        return -(dmg * 0.05f);
    }
}
