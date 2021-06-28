using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GantzDamage : MonoBehaviour
{
    // GantzのHP処理


    // クラス変数
    [SerializeField] private Image image;
    [SerializeField] private GameObject gantz;

    private SpriteRenderer sr;
    private GantzCore core;


    // 色変数
    private Color clearColor = new Color(1f, 0f, 0f, 1f);


    void Start()
    {
        // コンポーネント取得
        image = GetComponent<Image>();
        core = gantz.GetComponent<GantzCore>();
        sr = gantz.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // ダメージを受けた時に呼び出し
        if (core.DamageFlg)
        {
            // メソッド呼び出し
            HpGauge(core.GantzHp);
            Damage();
            //ShakePos();

            // ダメージを受けた時用フラグ
            core.DamageFlg = false;
        }
    }



    /// <summary>
    /// HPをImageとして表示する処理
    /// </summary>
    /// <param name="hp"></param>
    public void HpGauge(int hp)
    {
        // Imageを変化させる
        image.fillAmount = (float)hp / 100;
    }

    /// <summary>
    /// コルーチン呼び出し用処理
    /// </summary>k
    private void Damage()
    {
        StartCoroutine("Damage_ColorChange");
    }


    /// <summary>
    /// 透明度を変更する処理(コルーチン)
    /// </summary>k
    IEnumerator Damage_ColorChange()
    { 
        sr.color = clearColor;
        yield return new WaitForSeconds(0.1f);
        sr.color = new Color(1, 1, 1, 1);
    }

}
