using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 649
namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        // Enemyの攻撃処理

        // ステータス取得用変数
        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject bomb;

        [SerializeField] private AudioClip bombSE;

        private AudioSource audioSource;


        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }


        /// <summary>
        /// 当たり判定
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // collisionのコンポーネントを取得
            var e2GAttack = collision.gameObject.GetComponent<IE2GAttack>();

            if (e2GAttack != null)
            {
                // インターフェース呼び出し
                e2GAttack.ToGantzAttack(status.attackPower);

                // 爆破SE
                audioSource.PlayOneShot(bombSE);

                // Objectを消滅
                Destroy(gameObject,0.2f);

                // Effectを生成
                Instantiate(bomb).transform.position = transform.position;
            }
        }
    }

}
