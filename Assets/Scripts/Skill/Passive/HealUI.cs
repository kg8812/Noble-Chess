using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUI : EnemySkill
{
    public override bool CheckTargets()
    {
        return false;
    }

    public override bool CheckTargets(ChessSquare square)
    {
        return false;
    }

    public override bool CheckTargets(int idx1, int idx2)
    {
        return false;
    }
}
