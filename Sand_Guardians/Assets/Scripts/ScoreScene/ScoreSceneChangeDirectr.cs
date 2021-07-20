using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Bridge;

public class ScoreSceneChangeDirectr : MonoBehaviour
{
    // スコアシーン処理

    // Text変数
    [SerializeField] private Text score;
    [SerializeField] private Text enemyBreak;

    // 音用変数
    [SerializeField] private AudioClip buttonSE;
    private AudioSource audioSource;

    private IAddExp iAddExp;


    // Start is called before the first frame update
    void Start()
    {
        // コンポーネント取得
        audioSource = GetComponent<AudioSource>();

        iAddExp = new StatusChanger();
        iAddExp.AddExp(ScoreDirector.scorePoint);
    }

    // Update is called once per frame
    void Update()
    {
        // メソッド呼び出し
        SceneChage();
        DisplayText();
    }



    /// <summary>
    ///  シーン遷移処理
    /// </summary>
    private void SceneChage()
    {
        // Zキーでリトライ
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // シーン遷移
            FadeManager.Instance.LoadScene("GameScene", 0.5f);

            // ボタンのSE
            audioSource.PlayOneShot(buttonSE);

        }

        // Cキーでタイトル
        if (Input.GetKeyDown(KeyCode.C))
        {
            // シーン遷移
            FadeManager.Instance.LoadScene("StartMenuScene", 0.5f);

            // ボタンのSE
            audioSource.PlayOneShot(buttonSE);

        }
    }


   　/// <summary>
    /// Text表示処理
    /// </summary>
    private void DisplayText()
    {
        // text表示
        score.text = ScoreDirector.scorePoint.ToString("D4");
        enemyBreak.text = ScoreDirector.enemyBreak.ToString("D3");
    }

}
