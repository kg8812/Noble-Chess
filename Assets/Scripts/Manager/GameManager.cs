using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TurnManager;

public class GameManager : Singleton<GameManager>
{
    public bool isPlayerTurn { get; private set; }

    private void Start()
    {
        isPlayerTurn = true;
    }

    public void ChangeTurn()
    {       
        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn)
        {            
            TurnManager.Instance.StartTurn();
        }
        else
        {            
            EnemyTurnManager.Instance.StartTurn();
        }

        ChessBoard.Instance.Cancel();
        ChessBoard.Instance.ColorReset();
    }
}
