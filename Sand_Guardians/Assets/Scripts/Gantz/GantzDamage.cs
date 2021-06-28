using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GantzDamage : MonoBehaviour
{
    // Gantz��HP����


    // �N���X�ϐ�
    [SerializeField] private Image image;
    [SerializeField] private GameObject gantz;

    private SpriteRenderer sr;
    private GantzCore core;


    // �F�ϐ�
    private Color clearColor = new Color(1f, 0f, 0f, 1f);


    void Start()
    {
        // �R���|�[�l���g�擾
        image = GetComponent<Image>();
        core = gantz.GetComponent<GantzCore>();
        sr = gantz.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // �_���[�W���󂯂����ɌĂяo��
        if (core.DamageFlg)
        {
            // ���\�b�h�Ăяo��
            HpGauge(core.GantzHp);
            Damage();
            //ShakePos();

            // �_���[�W���󂯂����p�t���O
            core.DamageFlg = false;
        }
    }



    /// <summary>
    /// HP��Image�Ƃ��ĕ\�����鏈��
    /// </summary>
    /// <param name="hp"></param>
    public void HpGauge(int hp)
    {
        // Image��ω�������
        image.fillAmount = (float)hp / 100;
    }

    /// <summary>
    /// �R���[�`���Ăяo���p����
    /// </summary>k
    private void Damage()
    {
        StartCoroutine("Damage_ColorChange");
    }


    /// <summary>
    /// �����x��ύX���鏈��(�R���[�`��)
    /// </summary>k
    IEnumerator Damage_ColorChange()
    { 
        sr.color = clearColor;
        yield return new WaitForSeconds(0.1f);
        sr.color = new Color(1, 1, 1, 1);
    }

}
