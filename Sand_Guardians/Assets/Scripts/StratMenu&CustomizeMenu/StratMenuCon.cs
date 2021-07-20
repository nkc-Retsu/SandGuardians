using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StratMenuCon : MonoBehaviour
{
    [SerializeField] private GameObject stratBotton;        // ゲームスタートのボタン変数
    [SerializeField] private GameObject customizeBotton;    // カスタマイズのボタン変数
    [SerializeField] private GameObject cursor;             // ボタンに合わせるカーソル変数
    [SerializeField] private Text text;                     //　ボタンに対する説明のテキスト変数

    [SerializeField] private AudioClip cursorSE;            //　カーソル移動時のSE変数
    [SerializeField] private AudioClip BottonSE;            //　カーソル移動時のSE変数

    private int cursorInt;                                  //　カーソル移動の検知用の値

    private AudioSource audioSource;                        //　オーディオソース用変数

    private string stratText;                               // 説明用のテキストを入れるための文字列
    private string customizeText;                           //                 ''


    // Start is called before the first frame update
    void Start()
    {
        cursorInt = 0;                                      // 移動検知の値を初期化

        audioSource = GetComponent<AudioSource>();          // オーディオのコンポーネント取得

        stratText = "ゲームを開始します。";                   // テキスト表示の文字列     
        customizeText = "機体のカスタマイズを行います。";     // ''

    }

    // Update is called once per frame
    void Update()
    {
        // ↑キーを押したときの処理
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.PlayOneShot(cursorSE);
            cursorInt = 0;
        }

        // ↓キーを押したときの処理
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(cursorSE);
            cursorInt = 1;
        }

        // カーソルの移動を検知したとき
        if(cursorInt == 0)
        {
            cursor.transform.position = new Vector3(0f, 2.5f, 0);   // カーソルの位置を変更

            text.text = stratText;                                  // 説明用のテキスト

            // 決定キーを押したとき
            if(Input.GetKeyDown(KeyCode.X))
            {
                audioSource.PlayOneShot(BottonSE);
                FadeManager.Instance.LoadScene("GameScene", 0.5f);  // ゲームシーンに遷移
            }

        }

        if(cursorInt == 1)
        {
            cursor.transform.position = new Vector3(0f, -0.5f, 0);
            text.text = customizeText;

            if (Input.GetKeyDown(KeyCode.X))
            {
                audioSource.PlayOneShot(BottonSE);
                FadeManager.Instance.LoadScene("CustomizeScene", 0.5f); // カスタマイズシーンに遷移
            }

        }

    }
}
