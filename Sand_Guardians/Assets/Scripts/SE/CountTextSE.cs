using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountTextSE : MonoBehaviour
{

    [SerializeField] private AudioClip startSE;


    // �N���X�ϐ�
    private AudioSource audioSource;



    // Start is called before the first frame update
    void Start()
    {
        // �R���|�[�l���g�擾
        audioSource = GetComponent<AudioSource>();

        audioSource.PlayOneShot(startSE);

        Destroy(gameObject, 0.2f);
    }

}
