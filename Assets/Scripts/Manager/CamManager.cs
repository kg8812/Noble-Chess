using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : Singleton<CamManager>
{
    public GameObject[] cams;

    public void TCam()
    {
        cams[0].SetActive(true);
        cams[1].SetActive(false);
        cams[2].SetActive(false);
        ChessBoard.Instance.ChangeCam(true);
    }

    public void SCam()
    {
        cams[0].SetActive(false);
        cams[1].SetActive(true);
        cams[2].SetActive(false);
        ChessBoard.Instance.ChangeCam(false);

    }
    public void WCam()
    {
        cams[0].SetActive(false);
        cams[1].SetActive(false);
        cams[2].SetActive(true);
        ChessBoard.Instance.ChangeCam(false);
    }

    public void ResetCam()
    {
        for (int i = 0; i < 3; i++)
        {
            if (cams[i].activeSelf)
            {
                switch (i)
                {
                    case 0:
                        TCam();
                        break;
                    case 1:
                        SCam();
                        break;
                    case 2:
                        WCam();
                        break;
                }
            }
        }
    }
}
