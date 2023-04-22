using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuff : MonoBehaviour,IOnDmgBuff
{
    public int count = 0;

    public float GetBuff(float dmg)
    {
        return dmg * 0.05f * count;
    }
}
