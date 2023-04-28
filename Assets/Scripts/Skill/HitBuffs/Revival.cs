using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revival : Buff, IOnHit,IOnEndTurn
{
    bool isUsed = false;

    private void Start()
    {
        statusName = "소생";
        description = "유닛의 체력이 1 이하로 내려가는 피해를 1회 막고 해당 턴에 무적이 된다.";
        image = sm.revival.image;
    }
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
