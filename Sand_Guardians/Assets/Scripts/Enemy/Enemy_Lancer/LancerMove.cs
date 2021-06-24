using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 649
namespace Enemy
{
    public class LancerMove : MonoBehaviour
    {
        // EnemyLancerの動き処理


        // 取得用変数
        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject gantz;


        // 調整用変数
        [SerializeField, Tooltip("動き出すまでの時間")] private float timeUp;
        [SerializeField, Tooltip("止まる位置")] 　　　　private float movePos;


        // 移動処理用変数
        private Vector3 enemyPos;   // Enemyの位置変数
        private Vector3 gantzPos;   // Gantzの位置変数
        private Vector3 moveDir;    // EnemyからGantzへのベクトル変数
        private float distance_X;   // EnemyからGantzまでのx座標
        private float distance_Y;　 // EnemyからGantzまでのy座標
        private float time;         // 時間計測用変数
        private float speed;        // Enemyのスピード


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
            //メソッド呼び出し
            Move();
            Angle();
        }



        /// <summary>
        /// Enemyの移動処理
        /// </summary>
        private void Move()
        {
            // Enemyの位置を取得
            enemyPos = transform.position;

            // EnemyからGantzまでの距離を取得
            distance_X = gantzPos.x - enemyPos.x;
            distance_Y = gantzPos.y - enemyPos.y;


            // Enemyが移動する処理
            transform.position += moveDir.normalized * this.speed * Time.deltaTime;


            // Gantzの近くになると停止する
            if (Mathf.Abs(distance_X) <= movePos && Mathf.Abs(distance_Y) <= movePos)
            {
                // 移動速度を0にする
                this.speed = 0f;

                // 時間計測開始
                time += Time.deltaTime;
            }

            // 時間で動き出す
            if (time > timeUp) this.speed = 5f;

        }

        /// <summary>
        /// Enemyの方向処理
        /// </summary>
        private void Angle()
        {

            // Enemyの角度を取得
            float angle = (Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg) - 90.0f;

            // Enemyの位置によって向きを変更する
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

        }
    }

}
