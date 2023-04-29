using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Buff
{
    public float amount = 0;

    private void Start()
    {
        statusName = "보호막";
        description = $"{amount}만큼 받는 데미지를 막는다";
        image = sm.barrier.image;
    }
    private void Update()
    {
        cr.barrier = amount;       
    }
    public override void EndTurn()
    {
    }
    public float Shield(float dmg)
    {
        amount -= dmg;

        if (amount <= 0)
        {
            Destroy(this);
            cr.barrier = 0;
            return -amount;
        }

        return 0;
    }
}
