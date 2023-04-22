using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revival : Buff, IOnHit,IOnEndTurn
{
    bool isUsed = false;
    public float UseAbility(float curHp)
    {
        if (curHp <= 0)
        {
            cr.isInvincible = true;
            isUsed = true;
            return 1;
        }

        return curHp;
    }
    public override void EndTurn()
    {
        if (isUsed)
        {
            cr.isInvincible = false;
            Destroy(this);
        }
        else
        {
            base.EndTurn();
        }
    }
}
