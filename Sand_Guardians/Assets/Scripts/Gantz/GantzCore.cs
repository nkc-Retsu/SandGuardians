using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
public class GantzCore : MonoBehaviour,IE2GAttack
{
    // �K���c�̊�{����

    [SerializeField,Tooltip("�̗�")] private int gantzHp = 100;


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

    private bool damageFlg = false;

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
        if (gantzHp <= 0) Debug.Log("�V�[���J��");
    }

    /// <summary>
    /// Enemy��Gantz�ɍU������C���^�[�t�F�[�X����
    /// </summary>
    /// <param name="damage"></param>
    public void ToGantzAttack(int damage)
    {        
        gantzHp -= damage;
        damageFlg = true;
        HpDiretor();
    }

}
