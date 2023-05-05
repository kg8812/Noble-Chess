using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StatusEffect : MonoBehaviour,IPointerExitHandler,IPointerEnterHandler
{
    [SerializeField] Image statusImage;
    [SerializeField] Text duration;
    public Buff buff { get; private set; }
    
    StatusDescription description { get { return UIManager.Instance.statusDescription; } }
    public void OnPointerExit(PointerEventData eventData)
    {
        description.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        description.gameObject.SetActive(true);
        description.transform.position = transform.position + Vector3.left * 40;
        description.Set(buff);
    }
    private void Update()
    {
        Set(buff);
    }
    public void Set(Buff bf)
    {
        buff = bf;
        statusImage.sprite = bf.image;
        duration.text = bf.count.ToString();
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}
