using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour, IOnEndTurn
{
    public int count = 0;
    protected ChessPiece piece { get { return GetComponent<ChessPiece>(); } }
    protected Creature cr { get { return GetComponent<Creature>(); } }
    public virtual void EndTurn()
    {
        count--;
        if (count <= 0) Destroy(this);
    }   
}
