using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDescription : MonoBehaviour
{  
    public Text skillName;
    public Text description;
    public Text cd;
    public Text skillType;

    public void Set(Skill skill)
    {        
        skillName.text = skill.skillName;
        description.text = skill.description;

        if (skill.isPassive)
        {
            skillType.text = "패시브";
        }
        else if (skill.isImmediate)
        {
            skillType.text = "즉발형";
        }
        else
        {
            skillType.text = "예약형";
        }

        if (!skill.isPassive && skill.CurCD < 100 && skill.NormalCD > 0)
        {
            cd.text = skill.CurCD.ToString()+"/"+skill.NormalCD.ToString();
        }
        else
        {
            cd.text = "";
        }
    }

    public void Set()
    {       
        skillName.text = "";
        description.text = "";
        cd.text = "";
        skillType.text = "";
    }
}
