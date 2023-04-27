using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject behaviourOption; //선택 옵션
    public Text errorText; // 에러 텍스트
    public GameObject allAttackButton; // 일제 공격 버튼
    public GameObject attackCancelButton; // 공격 취소 버튼
    public SkillDescription skillDescription; // 스킬 설명창
    public SkillIcon[] skillIcons;   
    public Image illustration;
    public Button[] characterIcons;
    public GameObject skillEffect;
    public GameObject hpBarPrefab;
    public SpecialEffectUI specialSkillUI;
    public GameObject moveButton;
    public GameObject cancelButton;
    public Image turnImage;
    public Image turnImage2;

    public Text turnCount;
    public StatusDescription statusDescription;

    public void ShowText(string str,Color color, float time = 1)
    {
        turnImage.gameObject.SetActive(false);
        errorText.gameObject.SetActive(true);
        errorText.text = str;
        errorText.color = color;
        StartCoroutine(Disable(errorText.gameObject, time));
    }

    public void ShowTurnImage(bool isEnemy)
    {        
        turnImage.gameObject.SetActive(isEnemy);
        turnImage2.gameObject.SetActive(!isEnemy);

        StartCoroutine(Disable(turnImage.gameObject, 1));
        StartCoroutine(Disable(turnImage2.gameObject, 1));
    }
    IEnumerator Disable(GameObject obj,float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }   
    
    public void SetCharacterIcons()
    {
        for (int i = 0; i < characterIcons.Length && i < ChessBoard.Instance.ally.Count; i++) 
        {
            characterIcons[i].onClick.AddListener(ChessBoard.Instance.ally[i].Select);
            characterIcons[i].image.sprite = ChessBoard.Instance.ally[i].GetComponent<Creature>().render.sprite;
        }
    }

    public IEnumerator SetSkillEffect(Skill skill)
    {
        SkillEffectUI obj = Instantiate(skillEffect,skill.cr.render.transform).GetComponent<SkillEffectUI>();

        obj.pos = skill.cr.uiPos;
        obj.characterImage.sprite = skill.cr.portrait;
        obj.skillName.text = skill.skillName;
        obj.cr = skill.cr;

        yield return new WaitForSeconds(1);
        Destroy(obj.gameObject);
    }

    public IEnumerator SetSpecialSkillEffect(Skill skill)
    {
        specialSkillUI.gameObject.SetActive(true);
        
        specialSkillUI.portrait.sprite = skill.cr.portrait;
        specialSkillUI.skillName.text = skill.skillName;        

        yield return new WaitForSeconds(1);
        specialSkillUI.gameObject.SetActive(false);
    }
}
