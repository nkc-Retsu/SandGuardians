using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private IInputer inputer; // インプッター

        [SerializeField] private bool redFlg;
        private BulletPool bulletPool;
        [SerializeField] private GameObject poolObj;
        
        private Vector3 offsetPos; // 発射位置調整
        private float offsetRate = 0.2f; // 発射位置調整用

        private float timeSecondCounter = 0; // タイマー
        [SerializeField] private float attackSpan = 0.2f;　// 発射間隔

        private AudioSource audioSource;
        [SerializeField] AudioClip shotSound;

        void Start()
        {
            // コンポーネント取得
            inputer = GetComponent<IInputer>();
            attackSpan = GetComponent<IStatusGettable>().GetShotInterval();
            bulletPool = poolObj.GetComponent<BulletPool>();
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            timeSecondCounter -= Time.deltaTime; // タイマー減算

            if (inputer.Attack()) // 攻撃ボタンが押されていたら
            {
                if(timeSecondCounter<=0) // 発射間隔時間を経過していたら
                {
                    Attack(); // 攻撃処理呼び出し
                    timeSecondCounter = attackSpan; // タイマー再設定
                }
            }

        }

        void Attack()
        {
            offsetPos = transform.up * offsetRate; // 発射位置調整
            GameObject bullet;
            bullet = (redFlg) ? bulletPool.GetRedBullet() : bulletPool.GetBlueBullet();
            
            bullet.SetActive(true);
            bullet.transform.position = transform.position + offsetPos;
            bullet.transform.localEulerAngles = transform.localEulerAngles;
            audioSource.PlayOneShot(shotSound); // 音
        }
    }
}
