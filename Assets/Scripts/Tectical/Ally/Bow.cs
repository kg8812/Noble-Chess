using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : ChessPiece,IOnEndTurn
{
    public Creature cr;
    int count;

    protected override void Start()
    {
        base.Start();
        count = 2;
    }
    public void EndTurn()
    {
        int x = square.index1;
        int y = square.index2;
        
        for(int i = x - 1; i <= x + 1 && 0 <= i && i < 8; i++)
        {
            for(int j = y-1; j <= y + 1 && 0 <= j && j < 8; j++)
            {
                if (board.Squares[i, j].piece?.character != null)
                {                    
                    board.Squares[i, j].piece.character.CurHp += cr.MaxHp * 0.1f;
                }
            }
        }
        count--;
        if (count <= 0) Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        return;
    }   
}
