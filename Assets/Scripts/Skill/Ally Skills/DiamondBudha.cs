using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondBudha : MonoBehaviour,IOnNewTurn
{
    Creature cr { get { return GetComponent<Creature>(); } }
    float hp { get { return cr.CurHp / cr.MaxHp; } }

    public void StartNewTurn()
    {
        if (hp >= 0.5f)
        {
            Amplification amp = GetComponent<Amplification>();

            if (amp == null)
            {
                amp = gameObject.AddComponent<Amplification>();
            }
            amp.count++;

            Frality fr = GetComponent<Frality>();
            if (fr == null)
            {
                fr = gameObject.AddComponent<Frality>();
            }
            fr.count++;
        }
        else if (hp >= 0.25f)
        {
            Toughness tn = GetComponent<Toughness>();
            if (tn == null)
            {
                tn = gameObject.AddComponent<Toughness>();
            }
            tn.count++;
            Destroy(GetComponent<Amplification>());
        }
        else
        {
            Amplification amp = GetComponent<Amplification>();

            if (amp == null)
            {
                amp = gameObject.AddComponent<Amplification>();
            }

            amp.count++;

            Toughness tn = GetComponent<Toughness>();
            if (tn == null)
            {
                tn = gameObject.AddComponent<Toughness>();
            }
            tn.count++;
        }
    }
    
}
