using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    // 音用変数
    [SerializeField] private AudioClip bombSE;

    private AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        DestroyBomb();
    }

    /// <summary>
    /// 爆発する処理
    /// </summary>
    public void DestroyBomb()
    {
        audioSource.PlayOneShot(bombSE);

        Destroy(gameObject,0.5f);
    }
}
