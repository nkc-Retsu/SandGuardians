using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressAnyKey : MonoBehaviour
{
    // テキストの透明度を変化させる処理

    // クラス変数
    Color color = new Vector4(0, 0, 0, 0.8f); // 半透明状態変数
    Text text;

    // 透明度切り替え用フラグ
    bool up;


    void Start()
    {
        // コンポーネントを取得
        text = this.GetComponent<Text>();
    }

    void Update()
    {
        // 透明度変更処理
        // 透明度が変わったり元に戻ったりする
        if (text.color.a >= 0.8f) { up = false; }
        if (text.color.a <= 0.2f) { up = true; }
        if (up == true) { text.color += color * Time.deltaTime; }
        if (up == false) { text.color -= color * Time.deltaTime; }
    }
}
