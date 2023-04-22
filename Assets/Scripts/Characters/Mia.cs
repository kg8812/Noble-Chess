using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mia : Character,IOnNewTurn
{
    public BulletBuff bullet { get { return GetComponent<BulletBuff>(); } }

    protected override void Awake()
    {
        base.Awake();
        gameObject.AddComponent<BulletBuff>();
    }
    public override void StartNewTurn()
    {
        base.StartNewTurn();
        
        if (bullet.count < 4) bullet.count++;
    }
}
