using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public float amount = 0;

    public float Shield(float dmg)
    {
        amount -= dmg;

        if (amount <= 0)
        {
            Destroy(this);
            return -amount;
        }

        return 0;
    }
}
