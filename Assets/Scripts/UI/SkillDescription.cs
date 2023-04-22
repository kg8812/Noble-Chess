using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDescription : MonoBehaviour
{
    public Image skillImage;
    public Text skillName;
    public Text description;
    public Text cd;

    public void Set(Skill skill)
    {
        skillImage.sprite = skill.skillImage;
        skillName.text = skill.skillName;
        description.text = skill.description;

        if (skill.CurCD < 100)
        {
            cd.text = skill.CurCD.ToString();
        }
        else
        {
            cd.text = "";
        }
    }
}
