using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creation : EnemySkill
{       
    public override bool CheckTargets()
    {
        for(int i = 7; i >= 4; i--)
        {
            for(int j = 0; j < 8; j++)
            {
                if (board.Squares[i, j].piece == null)
                    return true;
            }
        }
        return false;
    }

    public override bool CheckTargets(ChessSquare square)
    {
        for (int i = 7; i >= 4; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board.Squares[i, j].piece == null)
                    return true;
            }
        }
        return false;
    }

    public override bool CheckTargets(int idx1, int idx2)
    {
        for (int i = 7; i >= 4; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board.Squares[i, j].piece == null)
                    return true;
            }
        }
        return false;
    }

    protected override void AddTargets()
    {
        base.AddTargets();        

        for (int i = 7; i >= 4; i--)
        {
            for (int j = 0; j < 8; j++)
            {
                if (board.Squares[i, j].piece == null)
                {
                    targets.Add(board.Squares[i, j]);
                }
                    
            }
        }       
    }
    public override void Use()
    {
        base.Use();
        int count = 0;
        
        List<int> list = new List<int>();
        
        for(int i = 0; i < targets.Count; i++)
        {
            if (count >= 2) break;

            if (targets[i] == null) continue;

            int rand = Random.Range(0, targets.Count);

            while (list.Contains(rand))
            {
                rand = Random.Range(0, targets.Count);
            }

            list.Add(rand);

            int x = targets[rand].index1;
            int y = targets[rand].index2;

            ChessPiece cp = board.action.AddPiece(x, y, "사명", false);

            GameObject obj = Instantiate(effect, cp.transform);
            obj.transform.position = cp.transform.position;

            cp.GetComponent<HealPassive>().healTarget = enemy;
            Destroy(obj, clip.length);
            count++;
        }                        
    }

    public override IEnumerator ShowEffect()
    {
        return null;
    }
}
