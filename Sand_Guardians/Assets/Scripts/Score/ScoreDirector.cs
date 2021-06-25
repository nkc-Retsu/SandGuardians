using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDirector : MonoBehaviour
{
    // スコア変数
    public static int scorePoint = 0;

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

    private void Score()
    {
        text.text = "Score  " + scorePoint.ToString("D4") ;
    }
}
