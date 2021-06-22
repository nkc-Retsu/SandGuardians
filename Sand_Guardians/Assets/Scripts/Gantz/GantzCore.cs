using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GantzCore : MonoBehaviour,IE2GAttack
{
    // ガンツの基本処理

    [SerializeField] private int hp = 100;


    /// <summary>
    /// HPの基本処理
    /// </summary>
    private void HpDiretor()
    {
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
