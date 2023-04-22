using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesireOfCollector : Skill
{
    public override void Ready()
    {
        base.Ready();

        if (cr.GetComponent<Collection>().count < 10)
        {
            UIManager.Instance.ShowText("수집품을 10개이상 모아야 합니다.", Color.red);
            return;
        }

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

        Toughness tg = gameObject.AddComponent<Toughness>();
        Amplification amp = gameObject.AddComponent<Amplification>();

        AddBuff(tg, 2);
        AddBuff(amp, 2);

        Destroy(tg);
        Destroy(amp);

        Skill[] skills = targetPiece.GetComponent<Character>().skills;

        for(int i = 0; i < skills.Length; i++)
        {
            skills[i].CurCD = 0;
        }
    }
}
