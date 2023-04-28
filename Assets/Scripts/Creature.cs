using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour, IOnNewTurn, IOnDamage
{
    public Transform uiPos;
    public bool isSkillUsed;
    public string Name;
    [SerializeField]
    protected float maxHp;
    [SerializeField]
    protected float curHp;
    public float CurHp
    {
        get { return curHp; }
        set
        {
            if (value < 0) curHp = 0;
            else if (value > maxHp) curHp = maxHp;
            else curHp = value;
        }
    }
    public float MaxHp
    {
        get { return maxHp; }
        set { maxHp = value; }
    }

    [SerializeField] float atk = 10;

    public float Atk
    {
        get
        {
            float dmg = atk;
            IOnDmgBuff[] buffs = GetComponents<IOnDmgBuff>();
            for (int i = 0; i < buffs.Length; i++)
            {
                dmg += buffs[i].GetBuff(atk);
            }
            return dmg;
        }
    }
    GameObject hpPrefab;
    public HpBar hpBar { get; protected set; }
    public SpriteRenderer render; // 스프라이트 렌더러 (캐릭터 이미지용)    
    public Sprite portrait;
    public bool isInvincible = false;
    public Sprite iconImage;
    protected virtual void Awake()
    {
        render = GetComponentInChildren<SpriteRenderer>();
    }
    protected virtual void Start()
    {
        hpPrefab = UIManager.Instance.hpBarPrefab;       
        hpBar = Instantiate(hpPrefab, GameObject.Find("Canvas").transform).GetComponent<HpBar>();
        hpBar.cr = this;
    }

    public void OnAttack(Creature target, float atk, float dmg)
    {
        IOnAttack[] attacks = gameObject.GetComponents<IOnAttack>();

        for (int i = 0; i < attacks.Length; i++)
        {
            attacks[i].OnAttack(target, atk, dmg);
        }
    }

    public void ChangeImage(bool is2D)  // 이미지 카메라에 맞춰서 변경
    {
        render.transform.rotation = Camera.main.transform.rotation;

        render.transform.localPosition = Vector3.zero;

        if (is2D)
        {
            render.transform.localPosition -= new Vector3(0, 0, 0.5f);
        }


        uiPos.localPosition = new Vector3(0, 1.2f, -0.2f);

    }

    public virtual void StartNewTurn()
    {
        isSkillUsed = false;
    }

    public virtual float OnHit(float dmg)
    {
        IOnDmgBuff[] buffs = GetComponents<IOnDmgBuff>();

        float cDmg = dmg;

        for (int i = 0; i < buffs.Length; i++)
        {
            dmg -= buffs[i].GetBuff(cDmg);
        }
        if (dmg > 0 && !isInvincible)
        {
            CurHp -= dmg;
        }

        dmg = GetComponent<Barrier>()?.Shield(dmg) ?? dmg;

        IOnHit[] onHits = GetComponents<IOnHit>();

        for (int i = 0; i < onHits.Length; i++)
        {
            CurHp = onHits[i].UseAbility(CurHp);
        }

        if (CurHp <= 0)
        {
            Destroy(gameObject);
        }

        return dmg;
    }
}
