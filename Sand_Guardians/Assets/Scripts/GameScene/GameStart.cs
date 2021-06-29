using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    // ゲームスタート時に表示するText処理

    // Text変数
    [SerializeField] private Text text;
    [SerializeField] private GameObject countSE;
    [SerializeField] private GameObject startSE;

    // 時間計測用変数
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // メソッド呼び出し
        TimeCount();
    }



    /// <summary>
    /// 時間を計測してTextを表示する処理
    /// </summary>
    private void TimeCount()
    {
        // 時間を計測
        time += Time.deltaTime;

        // 0秒の時
        if (time > 0f && time < 1f)
        {
            text.text = "3";

            //if(time > 0.9f && time < 1f) Instantiate(countSE);
        }
        // 1秒の時
        else if (time > 1f && time < 2f)
        {
            text.text = "2";

            //if (time > 1.95f && time < 2f) Instantiate(countSE);

        }
        // 2秒の時
        else if (time > 2f && time < 3f)
        {
            text.text = "1";

            //if (time > 2.95f && time < 3f) Instantiate(countSE);

        }
        // 3秒の時
        else if (time > 3f && time < 4f)
        {
            text.text = "Game Start";

            //if (time > 3.95f && time < 4f) Instantiate(startSE);

        }
        // 4秒以上の時はこのオブジェクトを消滅
        else if (time > 4f)
        {
            Destroy(gameObject);
            Destroy(text.gameObject);
        }


    }

}
