using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    AudioSource source;

    public AudioClip boss1;
    public AudioClip boss2;
    public AudioClip title;
    public AudioClip tutorial;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        source = GetComponent<AudioSource>();
        source.clip = title;
    }
    
    public void PlayMain()
    {
        source.clip = title;
        source.Play();
    }
    public void PlayTutorial()
    {
        source.clip = tutorial;
        source.Play();

    }
    public void PlayBoss1()
    {
        source.clip = boss1;
        source.Play();

    }
    public void PlayBoss2()
    {
        source.clip = boss2;
        source.Play();

    }
}
