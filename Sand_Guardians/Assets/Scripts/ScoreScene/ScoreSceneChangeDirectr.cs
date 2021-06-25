using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreSceneChangeDirectr : MonoBehaviour
{
    // スコアシーン処理

    // Text変数
    [SerializeField] private Text score;
    [SerializeField] private Text enemyBreak;


    // Start is called before the first frame update
    void Start()
    {

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
            FadeManager.Instance.LoadScene("GameScene", 0.5f);
            
            // スコアを初期化
            ScoreDirector.enemyBreak = 0;
            ScoreDirector.scorePoint = 0;
        }

        // Cキーでタイトル
        if (Input.GetKeyDown(KeyCode.C))
        {
            FadeManager.Instance.LoadScene("TitleScene", 0.5f);
            
            // スコアを初期化
            ScoreDirector.enemyBreak = 0;
            ScoreDirector.scorePoint = 0;

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
