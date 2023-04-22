using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOnAttack
{
    void OnAttack(Creature target,float atk,float dmg);
}
