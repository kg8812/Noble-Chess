using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy
{
    bool isMain = false;

    protected override void Start()
    {
        base.Start();
        if (isMain)
        {
            SoundManager.Instance.PlayBoss1();
        }
        else
        {
            SoundManager.Instance.PlayTutorial();
        }
        GetComponent<ChessPiece>().isMovable = false;
        isMain = GetComponent<Revival>() != null;
    }
    public override void StartNewTurn()
    {
        base.StartNewTurn();
        if (curHp == 1 && isMain) 
        {
            skills[1].CurCD = 0;
            curSkill = skills[1];
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();

        if (CurHp <= 0 && !isMain)
        {
            GameManager.Instance.GameOver(true);
        }
    }
}
