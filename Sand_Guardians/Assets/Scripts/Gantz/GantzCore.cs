using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GantzCore : MonoBehaviour,IE2GAttack
{
    // �K���c�̊�{����

    [SerializeField] private int hp = 100;


    /// <summary>
    /// HP�̊�{����
    /// </summary>
    private void HpDiretor()
    {
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
