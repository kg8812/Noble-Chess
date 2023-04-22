using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birth : EnemySkill
{
    public ChessPiece obj;

    private void Start()
    {
        CurCD = 99999;
    }

    public override bool CheckTargets()
    {
        return true;
    }

    public override bool CheckTargets(ChessSquare square)
    {
        return true;
    }

    public override bool CheckTargets(int idx1, int idx2)
    {
        return true;
    }

    public override void Use()
    {
        base.Use();
        Creature c = board.Replace(square.piece, obj).GetComponent<Creature>();

        for (int i = 0; i < ChessBoard.Instance.enemy.Count; i++)
        {
            if (ChessBoard.Instance.enemy[i].GetComponent<Creature>().Name == "숙명")
            {
                Skill skill = ChessBoard.Instance.enemy[i].GetComponent<Enemy>().skills[0];
                skill.Use();
                StartCoroutine(UIManager.Instance.SetSkillEffect(skill));
            }
        }      
    }
}
