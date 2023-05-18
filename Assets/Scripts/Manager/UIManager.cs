using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class UIManager : Singleton<UIManager>
{
    public GameObject behaviourOption; //선택 옵션
    public Text errorText; // 에러 텍스트
    public GameObject allAttackButton; // 일제 공격 버튼
    public GameObject attackCancelButton; // 공격 취소 버튼
    public SkillDescription skillDescription; // 스킬 설명창
    public SkillIcon[] skillIcons;   
    public Image illustration;    
    public GameObject skillEffect;
    public GameObject hpBarPrefab;
    public GameObject videoRawImage;
    public GameObject moveButton;
    public GameObject cancelButton;
    public Image turnImage;
    public Image turnImage2;
    public GameOverUI gameOver;

    public Text turnCount;
    public StatusDescription statusDescription;
    public GameObject enemyStatus;
    public BookUI bookUI;

    public VideoPlayer videoPlayer;

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

    public IEnumerator SetSkillProduction(Skill skill)
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
        videoRawImage.SetActive(true);
        videoPlayer.clip = skill.video;
        videoPlayer.Play();
        if (videoPlayer.clip != null)
        {
            yield return new WaitForSeconds((float)videoPlayer.clip.length);
        }
        videoPlayer.Pause();
        videoRawImage.SetActive(false);
    }

    public void GameOverUI(bool isWin)
    {
        gameOver.gameObject.SetActive(true);
        gameOver.Set(isWin);
    }        
}
