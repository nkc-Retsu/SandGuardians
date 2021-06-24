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

        // 代入用hp変数
        private int hp;



        private void Start()
        {
            // ステータスのhpを代入
            this.hp = status.hp;
        }

        /// <summary>
        /// HPの基本処理
        /// </summary>
        private void HpDirector()
        {
            // 体力が0になったら消滅
            if (this.hp <= 0)
            {
                ScoreDirector.scorePoint += status.enemyPoint;
                Debug.Log(ScoreDirector.scorePoint);
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
            HpDirector();
        }

        
    }

}
