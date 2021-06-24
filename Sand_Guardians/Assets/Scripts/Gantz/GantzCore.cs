using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
public class GantzCore : MonoBehaviour,IE2GAttack
{
    // ガンツの基本処理

    [SerializeField,Tooltip("体力")] private int hp = 100;


    /// <summary>
    /// HPの基本処理
    /// </summary>
    private void HpDiretor()
    {
        // 体力が0になったらシーン遷移
        if (hp <= 0) Debug.Log("シーン遷移");
    }

    /// <summary>
    /// EnemyがGantzに攻撃するインターフェース処理
    /// </summary>
    /// <param name="damage"></param>
    public void ToGantzAttack(int damage)
    {        
        hp -= damage;
        HpDiretor();
    }

}
