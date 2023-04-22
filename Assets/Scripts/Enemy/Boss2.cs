﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : Enemy
{
    protected override void Start()
    {
        base.Start();
        GetComponent<ChessPiece>().isMovable = false;
        skills[0].Use();
        for(int i = 0; i < ChessBoard.Instance.enemy.Count; i++)
        {
            if (ChessBoard.Instance.enemy[i].GetComponent<HealPassive>() != null)
            {
                ChessBoard.Instance.enemy[i].GetComponent<HealPassive>().healTarget = this;
            }          
        }
    }   
}
