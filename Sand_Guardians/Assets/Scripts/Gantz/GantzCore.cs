using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
public class GantzCore : MonoBehaviour,IE2GAttack
{
    // �K���c�̊�{����

    [SerializeField,Tooltip("�̗�")] private int hp = 100;


    /// <summary>
    /// HP�̊�{����
    /// </summary>
    private void HpDiretor()
    {
        // �̗͂�0�ɂȂ�����V�[���J��
        if (hp <= 0) Debug.Log("�V�[���J��");
    }

    /// <summary>
    /// Enemy��Gantz�ɍU������C���^�[�t�F�[�X����
    /// </summary>
    /// <param name="damage"></param>
    public void ToGantzAttack(int damage)
    {        
        hp -= damage;
        HpDiretor();
    }

}
