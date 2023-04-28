using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Mia : Character,IOnEndTurn
{
    public BulletBuff bullet { get { return GetComponent<BulletBuff>(); } }

    protected override void Awake()
    {
        base.Awake();
        gameObject.AddComponent<BulletBuff>();
    }

    protected override void Start()
    {
        base.Start();      

    }
    public void EndTurn()
    {
        if (bullet.count < 4) bullet.count++;
    }
}
