using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackCancelButton : MonoBehaviour
{
    private void OnMouseDown()
    {
        TurnManager.Instance.CancelSkill();
    }
}
