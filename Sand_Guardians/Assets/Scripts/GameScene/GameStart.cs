using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    // �Q�[���X�^�[�g���ɕ\������Text����

    // Text�ϐ�
    [SerializeField] private Text text;
    [SerializeField] private GameObject countSE;
    [SerializeField] private GameObject startSE;

    // ���Ԍv���p�ϐ�
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // ���\�b�h�Ăяo��
        TimeCount();
    }



    /// <summary>
    /// ���Ԃ��v������Text��\�����鏈��
    /// </summary>
    private void TimeCount()
    {
        // ���Ԃ��v��
        time += Time.deltaTime;

        // 0�b�̎�
        if (time > 0f && time < 1f)
        {
            text.text = "3";

            //if(time > 0.9f && time < 1f) Instantiate(countSE);
        }
        // 1�b�̎�
        else if (time > 1f && time < 2f)
        {
            text.text = "2";

            //if (time > 1.95f && time < 2f) Instantiate(countSE);

        }
        // 2�b�̎�
        else if (time > 2f && time < 3f)
        {
            text.text = "1";

            //if (time > 2.95f && time < 3f) Instantiate(countSE);

        }
        // 3�b�̎�
        else if (time > 3f && time < 4f)
        {
            text.text = "Game Start";

            //if (time > 3.95f && time < 4f) Instantiate(startSE);

        }
        // 4�b�ȏ�̎��͂��̃I�u�W�F�N�g������
        else if (time > 4f)
        {
            Destroy(gameObject);
            Destroy(text.gameObject);
        }


    }

}
