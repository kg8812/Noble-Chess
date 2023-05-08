using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesireOfCollector : Skill
{
    public override void Ready()
    {
        base.Ready();
        
        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Buff);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        Toughness tg = status.toughness;
        Amplification amp = status.amplification;

        AddBuff(tg, 2);
        AddBuff(amp, 2);       

        Skill[] skills = targetPiece.GetComponent<Character>().skills;

        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].CurCD = 0;
        }
    }
}
