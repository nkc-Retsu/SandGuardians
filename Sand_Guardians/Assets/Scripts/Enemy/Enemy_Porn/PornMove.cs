using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 649
namespace Enemy
{
    public class PornMove : MonoBehaviour
    {

        // EnemyPornの動き処理

        // 取得用変数
        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject gantz;


        // 移動処理用変数
        private Vector3 enemyPos;   // Enemyの位置
        private Vector3 gantzPos;   // Gantzの位置
        private Vector3 moveDir;    // 方向ベクトル
        private float speed;        // Enemyのspeed



        // Start is called before the first frame update
        void Start()
        {
            // Gantzのオブジェクトを取得
            gantz = GameObject.Find("Gantz");

            // ステータスのspeedを代入
            this.speed = status.speed;

            // 移動用の情報を取得
            enemyPos = transform.position;
            gantzPos = gantz.transform.position;

            // EnemyからGantzへのベクトルを取得
            moveDir = gantzPos - enemyPos;

        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Angle();
        }



        /// <summary>
        /// Enemyの移動処理
        /// </summary>
        private void Move()
        {
            // Enemyが移動する処理
            transform.position += moveDir.normalized * this.speed * Time.deltaTime;
        }

        /// <summary>
        /// Enemyの方向処理
        /// </summary>
        private void Angle()
        {

            // Enemyの角度を取得
            float angle = (Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg) - 90.0f;

            // Enemyの位置によって向きを変更する
            transform.rotation = Quaternion.Euler(0f,0f,angle);

        }
    }

}
