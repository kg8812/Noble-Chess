using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weakness : Buff, IOnDmgBuff
{
    public float GetBuff(float dmg)
    {
        return -(dmg * 0.1f);
    }
}
