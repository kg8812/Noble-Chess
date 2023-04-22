﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfSnare : Skill
{
    public override void Ready()
    {
        base.Ready();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Range);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        x = targetSquare.index1;
        y = targetSquare.index2;

        Snare sn = gameObject.AddComponent<Snare>();

        for (int i = x - 1; i <= x + 1 && 0 <= i && i < 8; i++)
        {
            for (int j = y - 1; j <= y + 1 && 0 <= j && j < 8; j++)
            {
                targetPiece = board.Squares[i, j].piece;

                if (targetPiece?.GetComponent<Enemy>() != null)
                {
                    AddTarget();
                }
            }
        }

        for (int i = 0; i < targetList.Count; i++)
        {
            targetPiece = targetList[i];
            AddBuff(sn, 2);
        }
        Destroy(sn);
    }
}