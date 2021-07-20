using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangetoGS : MonoBehaviour
{

    // 音用変数
    [SerializeField] private AudioClip buttonSE;

    private AudioSource audioSource;


    void Start()
    {
        // コンポーネント取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // シーン遷移
            FadeManager.Instance.LoadScene("StartMenuScene", 0.5f);

            // ボタンSE
            audioSource.PlayOneShot(buttonSE);
        }
        
    }
}
