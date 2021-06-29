using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextSE : MonoBehaviour
{

    [SerializeField] private AudioClip countSE;


    // �N���X�ϐ�
    private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(countSE);

        Destroy(gameObject, 0.2f);
    }

}
