using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snare : Buff
{
    bool isMove;
   
    private void Start()
    {
        if (piece == null) return;
        isMove = piece.isMovable;
        piece.isMovable = false;
        statusName = "속박";
        description = "이동에 방해를 받는다";
        image = sm.snare.image;
    }

    private void OnDestroy()
    {
        if (piece == null) return;

        piece.isMovable = isMove;
    }

}
