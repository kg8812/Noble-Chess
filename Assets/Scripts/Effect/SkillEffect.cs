using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffect : MonoBehaviour
{
    public AnimationClip clip;
    void Start()
    {
        Destroy(gameObject, clip.length);
    }   
}
