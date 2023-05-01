using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyEffect : MonoBehaviour
{
    public Projectile bullet;

    public void Fire()
    {
        Instantiate(bullet.gameObject, transform.position, bullet.transform.rotation);
    }


}
