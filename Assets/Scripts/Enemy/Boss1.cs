using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{
    bool isMain = false;

    protected override void Start()
    {
        base.Start();
        GetComponent<ChessPiece>().isMovable = false;
        isMain = GetComponent<Revival>() != null;
    }
    public override void StartNewTurn()
    {
        base.StartNewTurn();
        if (curHp == 1 && isMain) 
        {
            skills[1].CurCD = 0;
            curSkill = skills[1];
        }
    }   
}
