using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDescription : MonoBehaviour
{  
    public Text skillName;
    public Text description;
    public Text cd;

    public void Set(Skill skill)
    {        
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

    public void Set()
    {       
        skillName.text = "";
        description.text = "";
        cd.text = "";
    }
}
