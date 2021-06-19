using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class LancerMove : MonoBehaviour
    {

        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject gantz;


        // 移動処理用変数
        private Vector3 enemyPos;
        private Vector3 gantzPos;
        private Vector3 moveDir;



        // Start is called before the first frame update
        void Start()
        {
            // Gantzのオブジェクトを取得
            gantz = GameObject.Find("Gantz");

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
            // Enemyが移動する処理
            transform.position += moveDir.normalized * status.speed * Time.deltaTime;

            //if ()
            //{

            //}
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
