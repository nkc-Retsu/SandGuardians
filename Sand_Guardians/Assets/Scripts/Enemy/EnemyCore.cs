using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyCore : MonoBehaviour,IP2EAttack
    {
        // Enemyの基本処理

        // ステータスを持っている処理を取得
        [SerializeField] private EnemyStatus status;

        // Start is called before the first frame update
        void Start()
        {
            // コンポーネント取得
            //status = GetComponent<EnemyStatus>();
        }


        /// <summary>
        /// HPの基本処理
        /// </summary>
        private void HpDirector()
        {
            if (status.hp <= 0) Destroy(gameObject);
        }

        /// <summary>
        /// ダメージを受けた時のインターフェース処理
        /// </summary>
        /// <param name="damage"></param>
        public void ToEnemyAttack(int damage)
        {
            status.hp = -damage;
        }

        
    }

}
