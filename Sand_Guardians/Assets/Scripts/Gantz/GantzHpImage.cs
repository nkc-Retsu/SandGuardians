using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GantzHpImage : MonoBehaviour
{
    // Gantz��HP����


    // �N���X�ϐ�
    [SerializeField] private Image image;
    [SerializeField] private GameObject gantz;

    private GantzCore core;


    void Start()
    {
        // �R���|�[�l���g�擾
        image = GetComponent<Image>();
        core  = gantz.GetComponent<GantzCore>();
    }

    void Update()
    {
        // �_���[�W���󂯂����ɌĂяo��
        if(core.DamageFlg) HpGauge(core.GantzHp);
    }


    /// <summary>
    /// HP��Image�Ƃ��ĕ\�����鏈��
    /// </summary>
    /// <param name="hp"></param>
    public void HpGauge(int hp)
    {
        // Image��ω�������
        image.fillAmount = (float)hp / 100;

        // �_���[�W���󂯂����p�t���O
        core.DamageFlg = false;
    }
}
