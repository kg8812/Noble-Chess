using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stella : Character
{
    protected override void Awake()
    {
        base.Awake();
        gameObject.AddComponent<Collection>();
    }
}
