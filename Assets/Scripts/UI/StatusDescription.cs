using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDescription : MonoBehaviour
{
    public Text statusName;
    public Text description;

    public void Set(Buff buff)
    {
        statusName.text = buff.statusName;
        description.text = buff.description;
    }
  
}
