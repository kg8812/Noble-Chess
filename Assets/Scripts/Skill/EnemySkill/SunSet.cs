using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSet : EnemySkill
{
    [SerializeField] float atk;

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

    protected override void AddTargets()
    {
        base.AddTargets();

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                if (board.Squares[i, j].piece != null && board.Squares[i, j].piece.gameObject.CompareTag("Ally"))
                {
                    targets.Add(board.Squares[i, j]);
                }
            }
        }
    }

    public override void Use()
    {
        base.Use();
        try
        {
            for (int i = 0; i < targets.Count; i++)
            {                
                Creature p = targets[i]?.piece?.character;

                if (p == null) continue;

                float dmg = targets[i].piece.GetComponent<IOnDamage>().OnHit(enemy.Atk * atk);               
                enemy.OnAttack(p, enemy.Atk * atk, dmg);
            }
        }
        catch
        {
            return;
        }
    }

    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;
        if (cr == null) yield break;
        GameObject obj = Instantiate(effect, GameObject.Find("Canvas2").transform);
        obj.transform.position = cr.transform.position;
        yield return new WaitForSeconds(clip.length);
        Destroy(obj);
    }
}
