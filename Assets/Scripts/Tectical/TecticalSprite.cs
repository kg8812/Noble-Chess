using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TecticalSprite : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("클릭");
        transform.parent.GetComponent<ChessPiece>().Select();
    }
}
