using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public GameObject option;    
    public void OnClick()
    {
        option.SetActive(!option.activeSelf);
    }   
}
