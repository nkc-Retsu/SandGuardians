using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangetoGS : MonoBehaviour
{

    // ���p�ϐ�
    [SerializeField] private AudioClip buttonSE;

    private AudioSource audioSource;


    void Start()
    {
        // �R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // �V�[���J��
            FadeManager.Instance.LoadScene("StartMenuScene", 0.5f);

            // �{�^��SE
            audioSource.PlayOneShot(buttonSE);
        }
        
    }
}
