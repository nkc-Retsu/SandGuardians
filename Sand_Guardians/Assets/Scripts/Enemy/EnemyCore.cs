using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyCore : MonoBehaviour,IP2EAttack
    {
        // Enemyの基本処理

        // ステータス取得用変数
        [SerializeField] private EnemyStatus status;

        private int hp;

        private void Start()
        {
            this.hp = status.hp;
        }

        /// <summary>
        /// HPの基本処理
        /// </summary>
        private void HpDirector()
        {
            if (this.hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// ダメージを受けた時のインターフェース処理
        /// </summary>
        /// <param name="damage"></param>
        public void ToEnemyAttack(int damage)
        {
            this.hp -= damage;
            Debug.Log(hp);
            HpDirector();
        }

        
    }

}
