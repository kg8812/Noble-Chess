using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : Buff
{
    private void Start()
    {
        statusName = "수집품";
        description = "10스택시 수집가의 욕망 사용 가능";
        image = sm.collection.image;
    }
    public override void EndTurn()
    {
    }
}
