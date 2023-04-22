using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPassive : MonoBehaviour,IOnAttack
{
    public Creature healTarget;
    public float healAmount = 0.7f;

    public void OnAttack(Creature target, float atk,float dmg)
    {
        if (healTarget != null)
        {
            healTarget.CurHp += dmg * healAmount;
        }
    }  
}
