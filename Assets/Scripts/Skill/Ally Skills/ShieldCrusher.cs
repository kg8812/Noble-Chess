﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCrusher : Skill
{
    public override void Ready()
    {
        base.Ready();

        for (int i = x + 1; i <= x + 2; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Range);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        for (int i = x + 1; i <= x + 2; i++)
        {
            if (!(0 <= i && i < 8)) continue;

            for (int j = y - 1; j <= y + 1; j++)
            {
                if (!(0 <= j && j < 8)) continue;

                targetPiece = board.Squares[i, j].piece;

                AddTarget();
            }
        }

        for (int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];
            if (Attack(150))
            {
                FindObjectOfType<BurstBullet>().isEnhance = true;
            }
        }
    }
}
