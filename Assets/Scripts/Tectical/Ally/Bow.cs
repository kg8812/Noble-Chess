using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : ChessPiece,IOnEndTurn
{
    public Creature cr;
    int count;
    public GameObject effect;

    protected override void Start()
    {
        base.Start();
        count = 2;
    }
    public void EndTurn()
    {
        int x = square.index1;
        int y = square.index2;
        
        for(int i = x - 1; i <= x + 1; i++)
        {
            if (!(0 <= i && i < 8)) continue;

            for (int j = y-1; j <= y + 1; j++)
            {
                if (!(0 <= j && j < 8)) continue;

                if (board.Squares[i, j].piece?.character != null)
                {                    
                    board.Squares[i, j].piece.character.CurHp += cr.MaxHp * 0.1f;
                }
            }
        }
        count--;
        if (count <= 0)
        {
            Destroy(gameObject);
            GameObject obj = Instantiate(effect);
            obj.transform.position = transform.position - new Vector3(0, 0, 0.5f);
        }
    }  
}
