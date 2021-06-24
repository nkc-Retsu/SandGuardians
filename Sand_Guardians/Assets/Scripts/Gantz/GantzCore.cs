using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 649
public class GantzCore : MonoBehaviour,IE2GAttack
{
    // ガンツの基本処理

    [SerializeField,Tooltip("体力")] private int gantzHp = 100;


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
    /// HPの基本処理
    /// </summary>
    private void HpDiretor()
    {
        // 体力が0になったらシーン遷移
        if (gantzHp <= 0) Debug.Log("シーン遷移");
    }

    /// <summary>
    /// EnemyがGantzに攻撃するインターフェース処理
    /// </summary>
    /// <param name="damage"></param>
    public void ToGantzAttack(int damage)
    {        
        gantzHp -= damage;
        damageFlg = true;
        HpDiretor();
    }

}
