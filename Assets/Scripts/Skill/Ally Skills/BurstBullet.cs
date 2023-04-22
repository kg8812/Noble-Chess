﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstBullet : Skill
{
    public bool isEnhance = false;
   
    public override void Ready()
    {
        base.Ready();

        board.action.ChangeState(x + 1, y - 1, ChessSquare.SquareState.Attack);
        board.action.ChangeState(x + 1, y + 1, ChessSquare.SquareState.Attack);
    }

    public override void Use()
    {
        base.Use();

        float dmg = 100;
        if (isEnhance) dmg += 10;

        Attack(dmg);

        targetPiece = cr.GetComponent<ChessPiece>();

        AddBarrier(cr.Atk * 0.1f);

        isEnhance = false;
    }
}