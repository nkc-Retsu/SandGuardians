using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDirector : MonoBehaviour
{
    // �X�R�A����


    // �X�R�A�ϐ�(static�ϐ�)
    public static int scorePoint = 0;   // �X�R�A
    public static int enemyBreak = 0;   // �|����Enemy�̐�

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

    /// <summary>
    /// �X�R�A��Text�Ƃ��ĕ\�����鏈��
    /// </summary>
    private void Score()
    {
        text.text = "Score  " + scorePoint.ToString("D4") ;
    }
}
