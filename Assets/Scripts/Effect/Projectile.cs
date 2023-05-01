﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ChessSquare target;
    Vector3 startPos;
    Vector3 endPos;
    float moveTime;
    float lerpTime;
    Animator animator;
    bool isDestroyed = false;
    public void Destroy()
    {
        Destroy(gameObject);
    }
    private void Start()
    {
        startPos = transform.position;
        endPos = target.transform.position;
        moveTime = 1f;
        lerpTime = 0;    
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (lerpTime < moveTime)
        {
            lerpTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, endPos, lerpTime / moveTime);
        }
        else if(!isDestroyed)
        {
            isDestroyed = true;
            animator.SetTrigger("Explode");           
        }
    }
}
