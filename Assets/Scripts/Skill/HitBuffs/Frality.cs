using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frality : Buff, IOnHitBuff
{
    public float GetBuff(float dmg)
    {
        return -(dmg * 0.05f);
    }
}
