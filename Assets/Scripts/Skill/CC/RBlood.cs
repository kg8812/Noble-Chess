using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBlood : Buff
{
    private void OnEnable()
    {
        statusName = "잔혈";
        description = "특정 스킬의 대상이 된다";
    }
    public override void EndTurn()
    {
    }
}
