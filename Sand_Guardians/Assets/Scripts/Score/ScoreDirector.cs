using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDirector : MonoBehaviour
{
    // �X�R�A�ϐ�
    public static int scorePoint = 0;

    // Text�擾�p�ϐ�
    [SerializeField] private Text text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���\�b�h�Ăяo��
        Score();
    }

    private void Score()
    {
        text.text = "Score  " + scorePoint.ToString("D4") ;
    }
}
