using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    protected override void OnDestroy()
    {
        base.OnDestroy();

        if (CurHp <= 0)
        {
            GameManager.Instance.GameOver(false);
        }
    }
}
