using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour, IOnEndTurn
{
    public int count = 0;
    protected ChessPiece piece;
    protected Creature cr { get; private set; }
    public Sprite image;    
    public string description { get; protected set; }
    public string statusName { get; protected set; }
    protected StatusManager sm { get { return StatusManager.Instance; } }


    protected virtual void Awake()
    {
        cr = GetComponent<Creature>();
        piece = GetComponent<ChessPiece>();
    }

    public virtual void EndTurn()
    {
        count--;
        if (count <= 0) Destroy(this);
    }   
}
