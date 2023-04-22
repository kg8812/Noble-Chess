using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectUI : MonoBehaviour
{
    public SpriteRenderer characterImage;
    public TextMesh skillName;
    public Transform pos;
    public Creature cr;

    private void Start()
    {
        if (cr.hpBar != null)
        {
            cr.hpBar.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        transform.position = pos.position;             
    }
    private void OnDestroy()
    {
        if (cr.hpBar != null)
        {
            cr.hpBar.gameObject.SetActive(true);
        }
    }
}
