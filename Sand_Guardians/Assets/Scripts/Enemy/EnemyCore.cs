using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyCore : MonoBehaviour, IP2EAttack
    {
        // Enemyの基本処理

        // ステータス取得用変数
        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject bombObj;

        // 代入用hp変数
        private int hp;

        private bool damgeFlg = false;
        
        public bool DamageFlg
        {
            get
            {
                return damgeFlg;
            }
            set
            {
                damgeFlg = value;
            }
        }
        

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
                // スコアにポイントを加算
                ScoreDirector.scorePoint += status.enemyPoint;

                // 倒したEnemyを++していく 
                ScoreDirector.enemyBreak++;

                // 爆発オブジェクトを生成
                Instantiate(bombObj).transform.position = transform.position;

                // 敵を消滅
                Destroy(gameObject,0.2f);
            }
        }

        /// <summary>
        /// ダメージを受けた時のインターフェース処理
        /// </summary>
        /// <param name="damage"></param>
        public void ToEnemyAttack(int damage, ref bool isDead)
        {
            // hpをdamage分減少
            this.hp -= damage;

            if (hp <= 0) isDead = true;
            else isDead = false;

            // HPメソッド呼び出し
            HpDirector();

            damgeFlg = true;
        }


    }

}
