using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StratMenuCon : MonoBehaviour
{
    [SerializeField] private GameObject stratBotton;        // �Q�[���X�^�[�g�̃{�^���ϐ�
    [SerializeField] private GameObject customizeBotton;    // �J�X�^�}�C�Y�̃{�^���ϐ�
    [SerializeField] private GameObject cursor;             // �{�^���ɍ��킹��J�[�\���ϐ�
    [SerializeField] private Text text;                     //�@�{�^���ɑ΂�������̃e�L�X�g�ϐ�

    [SerializeField] private AudioClip cursorSE;            //�@�J�[�\���ړ�����SE�ϐ�
    [SerializeField] private AudioClip BottonSE;            //�@�J�[�\���ړ�����SE�ϐ�

    private int cursorInt;                                  //�@�J�[�\���ړ��̌��m�p�̒l

    private AudioSource audioSource;                        //�@�I�[�f�B�I�\�[�X�p�ϐ�

    private string stratText;                               // �����p�̃e�L�X�g�����邽�߂̕�����
    private string customizeText;                           //                 ''


    // Start is called before the first frame update
    void Start()
    {
        cursorInt = 0;                                      // �ړ����m�̒l��������

        audioSource = GetComponent<AudioSource>();          // �I�[�f�B�I�̃R���|�[�l���g�擾

        stratText = "�Q�[�����J�n���܂��B";                   // �e�L�X�g�\���̕�����     
        customizeText = "�@�̂̃J�X�^�}�C�Y���s���܂��B";     // ''

    }

    // Update is called once per frame
    void Update()
    {
        // ���L�[���������Ƃ��̏���
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            audioSource.PlayOneShot(cursorSE);
            cursorInt = 0;
        }

        // ���L�[���������Ƃ��̏���
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(cursorSE);
            cursorInt = 1;
        }

        // �J�[�\���̈ړ������m�����Ƃ�
        if(cursorInt == 0)
        {
            cursor.transform.position = new Vector3(0f, 2.5f, 0);   // �J�[�\���̈ʒu��ύX

            text.text = stratText;                                  // �����p�̃e�L�X�g

            // ����L�[���������Ƃ�
            if(Input.GetKeyDown(KeyCode.X))
            {
                audioSource.PlayOneShot(BottonSE);
                FadeManager.Instance.LoadScene("GameScene", 0.5f);  // �Q�[���V�[���ɑJ��
            }

        }

        if(cursorInt == 1)
        {
            cursor.transform.position = new Vector3(0f, -0.5f, 0);
            text.text = customizeText;

            if (Input.GetKeyDown(KeyCode.X))
            {
                audioSource.PlayOneShot(BottonSE);
                FadeManager.Instance.LoadScene("CustomizeScene", 0.5f); // �J�X�^�}�C�Y�V�[���ɑJ��
            }

        }

    }
}
