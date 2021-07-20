using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StratMenuCon : MonoBehaviour
{
    [SerializeField] private GameObject stratBotton;
    [SerializeField] private GameObject customizeBotton;
    [SerializeField] private GameObject cursor;
    [SerializeField] private Text text;
    private int cursorInt;
    private SpriteRenderer stratBottonRenderer;
    private SpriteRenderer customizeBottonRenderer;

    private string stratText;
    private string customizeText;


    // Start is called before the first frame update
    void Start()
    {
        cursorInt = 0;

        stratBottonRenderer = stratBotton.GetComponent<SpriteRenderer>();
        customizeBottonRenderer = customizeBotton.GetComponent<SpriteRenderer>();

        stratText = "ゲームを開始します。";
        customizeText = "機体のカスタマイズを行います。";

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            cursorInt = 0;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            cursorInt = 1;
        }

        if(cursorInt == 0)
        {
            cursor.transform.position = new Vector3(0f, 2.5f, 0);

            text.text = stratText;

            if(Input.GetKeyDown(KeyCode.X))
            {
                FadeManager.Instance.LoadScene("MiwaScene", 0.5f);
            }

        }

        if(cursorInt == 1)
        {
            cursor.transform.position = new Vector3(0f, -0.5f, 0);
            text.text = customizeText;

            if (Input.GetKeyDown(KeyCode.X))
            {
                FadeManager.Instance.LoadScene("CustomizeScene", 0.5f);
            }

        }

    }
}
