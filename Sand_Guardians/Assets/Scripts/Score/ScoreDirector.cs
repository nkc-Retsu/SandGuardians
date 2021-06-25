using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDirector : MonoBehaviour
{
    // スコア処理


    // スコア変数(static変数)
    public static int scorePoint = 0;   // スコア
    public static int enemyBreak = 0;   // 倒したEnemyの数

    // Text取得用変数
    [SerializeField] private Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // メソッド呼び出し
        Score();
    }

    /// <summary>
    /// スコアをTextとして表示する処理
    /// </summary>
    private void Score()
    {
        text.text = "Score  " + scorePoint.ToString("D4") ;
    }
}
