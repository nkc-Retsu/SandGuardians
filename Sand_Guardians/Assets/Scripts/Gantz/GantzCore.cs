using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


#pragma warning disable 649
public class GantzCore : MonoBehaviour,IE2GAttack
{
    // ガンツの基本処理


    [SerializeField,Tooltip("体力")] private int gantzHp = 100;
    // ↑プロパティ
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



    // ダメージを受けた時用フラグ
    private bool damageFlg = false;
    // ↑プロパティ
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
        if (gantzHp <= 0) FadeManager.Instance.LoadScene("ScoreScnen",0.5f);
    }

    /// <summary>
    /// EnemyがGantzに攻撃するインターフェース処理
    /// </summary>
    /// <param name="damage"></param>
    public void ToGantzAttack(int damage)
    {        
        // hpをdamage文減少
        gantzHp -= damage;

        // ダメージを受けた時用フラグ
        damageFlg = true;

        // hp処理呼び出し
        HpDiretor();
    }

}
