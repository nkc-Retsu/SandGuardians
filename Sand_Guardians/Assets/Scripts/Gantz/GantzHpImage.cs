using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GantzHpImage : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject gantz;

    private GantzCore core;


    void Start()
    {
        image = GetComponent<Image>();
        core  = gantz.GetComponent<GantzCore>();
    }

    void Update()
    {
        if(core.DamageFlg) HpGauge(core.GantzHp);
    }


    /// <summary>
    /// HP��Image�Ƃ��ĕ\�����鏈��
    /// </summary>
    /// <param name="hp"></param>
    public void HpGauge(int hp)
    {
        Debug.Log("�����Ă�");
        image.fillAmount = (float)hp / 100;
        core.DamageFlg = false;
    }
}
