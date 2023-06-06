using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Button Restart;
    public Button ToTitle;
    public Button Exit;
    private void Start()
    {
        Restart.onClick.AddListener(GameManager.Instance.GameReset);
        Exit.onClick.AddListener(GameManager.Instance.EndGame);
    }
    
    public void ToTitleMenu()
    {
        SceneMan.Instance.ToTitle();
    }

    public void RestartGame()
    {
        GameManager.Instance.GameReset();
    }

    public void ExitGame()
    {
        GameManager.Instance.EndGame();
    }
}
