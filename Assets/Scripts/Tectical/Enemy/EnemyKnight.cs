using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : EnemyChessPiece
{
    public override bool CheckSkillAfterMove()
    {
        if (!base.CheckSkillAfterMove()) return false;

        int x = square.index1;
        int y = square.index2;

        if (enemy.curSkill.CheckTargets(x + 2, y - 1)) AddMoveList(x + 2, y - 1);
        if (enemy.curSkill.CheckTargets(x + 2, y + 1)) AddMoveList(x + 2, y + 1);
        if (enemy.curSkill.CheckTargets(x - 2, y - 1)) AddMoveList(x - 2, y - 1);
        if (enemy.curSkill.CheckTargets(x - 2, y + 1)) AddMoveList(x - 2, y + 1);
        if (enemy.curSkill.CheckTargets(x - 1, y + 2)) AddMoveList(x - 1, y + 2);
        if (enemy.curSkill.CheckTargets(x + 1, y + 2)) AddMoveList(x + 1, y + 2);
        if (enemy.curSkill.CheckTargets(x - 1, y - 2)) AddMoveList(x - 1, y - 2);
        if (enemy.curSkill.CheckTargets(x + 1, y - 2)) AddMoveList(x + 1, y - 2);

        return mList.Count > 0;
    }

    public override void CheckMoves()
    {
        base.CheckMoves();

        int x = square.index1;
        int y = square.index2;

        AddMoveList(x + 2, y - 1);
        AddMoveList(x + 2, y + 1);
        AddMoveList(x - 2, y - 1);
        AddMoveList(x - 2, y + 1);
        AddMoveList(x - 1, y + 2);
        AddMoveList(x + 1, y + 2);
        AddMoveList(x - 1, y - 2);
        AddMoveList(x + 1, y - 2);
    }
}
