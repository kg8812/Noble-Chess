using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourUI : MonoBehaviour
{
    private void OnEnable()
    {
        UIManager.Instance.illustration.sprite = ChessBoard.Instance.selected.piece.GetComponent<Creature>().portrait;
        bool isEnemy = ChessBoard.Instance.selected.piece.gameObject.CompareTag("Enemy");

        UIManager.Instance.moveButton.SetActive(!isEnemy);
        UIManager.Instance.cancelButton.SetActive(!isEnemy);

        Skill[] skills;

        if (isEnemy)
        {
            skills = ChessBoard.Instance.selected.piece.GetComponent<Enemy>().skills;
        }
        else
        {
            skills = ChessBoard.Instance.selected.piece.character.skills;
        }
        for (int i = 0; i < skills.Length; i++)
        {
            UIManager.Instance.skillIcons[i].skill = skills[i];
            UIManager.Instance.skillIcons[i].Set();
        }
        for(int i = skills.Length; i < UIManager.Instance.skillIcons.Length; i++)
        {
            UIManager.Instance.skillIcons[i].skill = null;
        }
        for(int i = 0; i < UIManager.Instance.skillIcons.Length; i++)
        {
            if (UIManager.Instance.skillIcons[i].skill == null)
            {
                UIManager.Instance.skillIcons[i].gameObject.SetActive(false);
            }
            else
            {
                UIManager.Instance.skillIcons[i].gameObject.SetActive(true);

            }
        }
    }

    
}
