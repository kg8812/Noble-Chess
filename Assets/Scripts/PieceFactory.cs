using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PieceFactory : Singleton<PieceFactory>
{
    [SerializeField] List<ChessPiece> ally = new List<ChessPiece>();
    [SerializeField] List<ChessPiece> enemy = new List<ChessPiece>();
    [SerializeField] Vector2[] allyPos;
    [SerializeField] Vector2[] enemyPos;

    [SerializeField] ChessPiece[] UnitList;
    
    protected override void Awake()
    {
        base.Awake();        
    }
    
    public void CreatePieces(List<ChessPiece> cp,bool isAlly)
    {       
        if (isAlly)
        {
            for(int i = 0; i < ally.Count; i++)
            {
                cp.Add(Instantiate(ally[i], GameObject.Find("Characters").transform));
                cp[i].pos1 = (int)allyPos[i].x;
                cp[i].pos2 = (int)allyPos[i].y;
            }
        }
        else
        {
            for (int i = 0; i < enemy.Count; i++)
            {
                cp.Add(Instantiate(enemy[i], GameObject.Find("Characters").transform));
                cp[i].pos1 = (int)enemyPos[i].x;
                cp[i].pos2 = (int)enemyPos[i].y;
            }
        }       
    }

    public ChessPiece Create(string pName)
    {
        for(int i = 0; i < UnitList.Length; i++)
        {
            if(UnitList[i].GetComponent<Creature>().Name == pName)
            {
                return Instantiate(UnitList[i], GameObject.Find("Characters").transform);
            }
        }

        return null;
    }
}