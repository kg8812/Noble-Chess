using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookUI : MonoBehaviour
{  
    Image[] images = new Image[16];
    Queue<Skill> skillQueue = new Queue<Skill>();
    public GameObject reservedSkill;

    void Start()
    {                      
        for(int i = 0; i < 16; i++)
        {
            Image image = Instantiate(reservedSkill,transform).GetComponent<Image>();                        
            images[i] = image;
            image.gameObject.SetActive(false);           
        }
    }  

    public void Add(Skill skill)
    {
        images[skillQueue.Count].gameObject.SetActive(true);
        images[skillQueue.Count].sprite = skill.cr.iconImage;
        images[skillQueue.Count].GetComponent<ReservedSkill>().Set(skill);
        skillQueue.Enqueue(skill);              
    }

    public void Cancel()
    {
        for(int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false); 
            images[i].sprite = null;
        }
        skillQueue.Clear();
    }

    public void Remove()
    {
        skillQueue.Dequeue();
        int i = 0;
        foreach( Skill skill in skillQueue)
        {
            images[i].GetComponent<ReservedSkill>().Set(skill);
            images[i++].sprite = skill.cr.iconImage;         
        }

        images[i].gameObject.SetActive(false);
    }
}
