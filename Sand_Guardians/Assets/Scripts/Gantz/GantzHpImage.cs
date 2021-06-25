using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GantzHpImage : MonoBehaviour
{
    // GantzのHP処理


    // クラス変数
    [SerializeField] private Image image;
    [SerializeField] private GameObject gantz;

    private GantzCore core;


    void Start()
    {
        // コンポーネント取得
        image = GetComponent<Image>();
        core  = gantz.GetComponent<GantzCore>();
    }

    void Update()
    {
        // ダメージを受けた時に呼び出し
        if(core.DamageFlg) HpGauge(core.GantzHp);
    }


    /// <summary>
    /// HPをImageとして表示する処理
    /// </summary>
    /// <param name="hp"></param>
    public void HpGauge(int hp)
    {
        // Imageを変化させる
        image.fillAmount = (float)hp / 100;

        // ダメージを受けた時用フラグ
        core.DamageFlg = false;
    }
}
