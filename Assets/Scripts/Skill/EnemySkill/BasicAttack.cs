using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : EnemySkill
{

    public override bool IsUsable()
    {
        return base.IsUsable();
    }

    protected override void AddTargets()
    {
        base.AddTargets();

        int x = square.index1;
        int y = square.index2;

        targets = board.action.CheckInRange(1, x, y, false, board.action.CheckAttackable);
    }
    public override bool CheckTargets()
    {
        int x = square.index1;
        int y = square.index2;

        List<ChessSquare> list = board.action.CheckInRange(1, x, y, false, board.action.CheckAttackable);
        
        return list.Count > 0;
    }
    public override bool CheckTargets(ChessSquare square)
    {
        int x = square.index1;
        int y = square.index2;

        return board.action.CheckInRange(1, x, y, false, board.action.CheckAttackable).Count > 0;
    }
    public override bool CheckTargets(int idx1, int idx2)
    {
        return board.action.CheckInRange(1, idx1, idx2, false, board.action.CheckAttackable).Count > 0;
    }
    
    public override void Use()
    {        
        base.Use();

        PickTarget();
        float dmg = targetSquare.piece.GetComponent<IOnDamage>().OnHit(enemy.Atk);

        enemy.OnAttack(targetSquare.piece.character, enemy.Atk, dmg);
    }   
}
