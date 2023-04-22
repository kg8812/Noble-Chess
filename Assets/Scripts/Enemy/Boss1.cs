using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{
    protected override void Start()
    {
        base.Start();
        GetComponent<ChessPiece>().isMovable = false;
    }
    public override void StartNewTurn()
    {
        base.StartNewTurn();
        if (curHp == 1)
        {
            skills[1].CurCD = 0;
            curSkill = skills[1];
        }
    }   
}
