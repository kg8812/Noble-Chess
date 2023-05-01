using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabbing : Skill
{   
    public GameObject effect2;

    public override void Ready()
    {
        base.Ready();

        for(int i = y - 1; i <= y + 1; i++)
        {
            board.action.ChangeState(x + 2, i, ChessSquare.SquareState.Attack);
        }
    }
    public override void Use()
    {
        base.Use();        
        Attack(100);
    }

    public override IEnumerator ShowEffect()
    {
        GameObject obj = Instantiate(effect,cr.transform);
        obj.transform.position = cr.transform.position;

        Vector3 dir = obj.transform.rotation.eulerAngles;
        obj.transform.LookAt(targetPiece.transform);
        obj.transform.rotation = Quaternion.Euler(dir + obj.transform.rotation.eulerAngles);

        int x = targetSquare.index1;
        int y = targetSquare.index2;       

        if (board.Squares[x - 1, y].piece == null)
        {
            yield return StartCoroutine(cr.GetComponent<ChessPiece>().StartMove(x - 1, y));
        }

        Destroy(obj);
        Instantiate(effect2, targetPiece.transform.position, effect2.transform.rotation);       
    }
}
