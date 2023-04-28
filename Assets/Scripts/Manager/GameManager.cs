using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TurnManager;

public class GameManager : Singleton<GameManager>
{
    public bool isPlayerTurn { get; private set; }
    private bool isGameOver;

    private void Start()
    {
        isGameOver = false;
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

    public void GameOver()
    {
        isGameOver = true;
    }
}
