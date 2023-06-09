﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public GameObject winImage;
    public GameObject loseImage;
    public Button restart;
    public Button exit;
    Image bg { get { return GetComponent<Image>(); } }

    public void Set(bool IsWin)
    {
        if (IsWin)
        {
            winImage.SetActive(true);
            loseImage.SetActive(false);
            bg.color = new Color(1, 1, 1, 0);
        }
        else
        {
            winImage.SetActive(false);
            loseImage.SetActive(true);
            bg.color = new Color(0, 0, 0, 0.5f);
        }
    }

    public void Restart()
    {
        GameManager.Instance.GameReset();
    }

    public void ToTitle()
    {
        SceneMan.Instance.ToTitle();
    }

}
