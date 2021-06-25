using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


#pragma warning disable 649
public class GantzCore : MonoBehaviour,IE2GAttack
{
    // �K���c�̊�{����


    [SerializeField,Tooltip("�̗�")] private int gantzHp = 100;
    // ���v���p�e�B
    public int GantzHp
    {
        get
        {
            return gantzHp;
        }
        set
        {
            gantzHp = value;
        }
    }



    // �_���[�W���󂯂����p�t���O
    private bool damageFlg = false;
    // ���v���p�e�B
    public bool DamageFlg
    {
        get
        {
            return damageFlg;
        }
        set
        {
            damageFlg = value;
        }
    }



    /// <summary>
    /// HP�̊�{����
    /// </summary>
    private void HpDiretor()
    {
        // �̗͂�0�ɂȂ�����V�[���J��
        if (gantzHp <= 0) FadeManager.Instance.LoadScene("ScoreScnen",0.5f);
    }

    /// <summary>
    /// Enemy��Gantz�ɍU������C���^�[�t�F�[�X����
    /// </summary>
    /// <param name="damage"></param>
    public void ToGantzAttack(int damage)
    {        
        // hp��damage������
        gantzHp -= damage;

        // �_���[�W���󂯂����p�t���O
        damageFlg = true;

        // hp�����Ăяo��
        HpDiretor();
    }

}
