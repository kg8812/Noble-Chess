using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : Singleton<StatusManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
    public Amplification amplification;  //증폭
    public Frality frality;    //취약
    public Toughness toughness; // 강인함
    public FoxFireStack foxFireStack; // 여우불스택
    public RBlood rBlood; // 잔혈
    public Snare snare; // 속박
    public BulletBuff bulletBuff; // 탄환
    public Collection collection; // 수집품
    public Weakness weakness; // 약화
    public Barrier barrier; // 배리어
    public Revival revival;   // 소생
}
