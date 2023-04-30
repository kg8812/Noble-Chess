using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    CanvasScaler scaler;

    private void Start()
    {       
        scaler = GetComponent<CanvasScaler>();
    }
    public void ChangeScale()
    {
        int width = Screen.width;
        int height = Screen.height;
        scaler.referenceResolution = new Vector2(width, height);
    }
}
