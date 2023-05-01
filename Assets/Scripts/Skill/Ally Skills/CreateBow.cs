using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBow : Skill
{
    public GameObject bow;
    public override void Ready()
    {
        base.Ready();

        for(int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 8; j++)
            {
                board.action.ChangeState(i, j, ChessSquare.SquareState.Place);
            }
        }
    }

    public override void Use()
    {
        base.Use();

        GameObject obj = Instantiate(this.bow, GameObject.Find("Characters").transform);
        Bow bow = obj.GetComponent<Bow>();
        bow.cr = cr;

        bow.pos1 = targetSquare.index1;
        bow.pos2 = targetSquare.index2;
        board.ally.Add(bow);
        board.SetPosition(bow);

    }

    public override IEnumerator ShowEffect()
    {
        if (effect == null) yield break;

        GameObject obj = Instantiate(effect);
        obj.transform.position = targetSquare.transform.position - new Vector3(0,0,0.5f);
        yield return new WaitForSeconds(clip.length);
        Destroy(obj);
    }
}
