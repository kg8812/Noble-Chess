using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManager : MonoBehaviour
{
    public void ToTuto()
    {
        SceneMan.Instance.ToTutorial();
    }

    public void ToMain()
    {
        SceneMan.Instance.ToMain();
    }

    public void ExitGame()
    {
        GameManager.Instance.EndGame();
    }
}
