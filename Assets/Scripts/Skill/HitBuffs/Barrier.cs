using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Buff
{
    public float amount = 0;

    public override void EndTurn()
    {
    }
    public float Shield(float dmg)
    {
        amount -= dmg;

        if (amount <= 0)
        {
            Destroy(this);
            return -amount;
        }

        return 0;
    }
}
