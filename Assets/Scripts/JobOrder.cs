using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobOrder : MonoBehaviour
{
    void Start()
    {
        ChessBoard.Instance.Create();
        CamManager.Instance.TCam();        
        TurnManager.Instance.StartTurn();
        EnemyTurnManager.Instance.StartJob();
    }   
}
