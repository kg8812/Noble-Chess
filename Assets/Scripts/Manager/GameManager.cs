using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isPlayerTurn { get; private set; }
    public bool isGameOver { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        isGameOver = false;
        isPlayerTurn = true;
    }

    public void ChangeTurn()
    {
        if (isGameOver) return;

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

    public void GameOver(bool isWin)
    {
        isGameOver = true;
        UIManager.Instance.GameOverUI(isWin);
    }

    public void GameReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Start();
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
