using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxFireStack : Buff
{   

    private void Start()
    {
        count = 0;
        statusName = "여우불";
        description = "스택만큼 특정 스킬의 데미지가 증가한다";
        image = sm.foxFireStack.image;
    }

    public override void EndTurn()
    {
    }
}
