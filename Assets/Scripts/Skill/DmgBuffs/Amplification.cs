﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplification : Buff, IOnDmgBuff
{
    private void Start()
    {
        statusName = "증폭";
        description = "공격력이 10% 증가한다";
        image = sm.amplification.image;
    }
    public float GetBuff(float dmg)
    {
        return dmg *= 0.1f;
    }    
}
