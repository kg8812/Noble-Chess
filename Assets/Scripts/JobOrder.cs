using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobOrder : MonoBehaviour
{
    void Start()
    {
        ChessBoard.Instance.Create();
        CamManager.Instance.TCam();
        UIManager.Instance.SetCharacterIcons();
        TurnManager.Instance.StartTurn();
        EnemyTurnManager.Instance.StartJob();
    }   
}
