using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMan : Singleton<SceneMan>
{
    protected override void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ToTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void ToMain()
    {
        SceneManager.LoadScene(2);
    }

    public void ToTitle()
    {
        SoundManager.Instance.PlayMain();
        SceneManager.LoadScene(0);
    }
}
