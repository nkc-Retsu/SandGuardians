using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 649
namespace Enemy
{
    public class KnightMove : MonoBehaviour
    {
        // EnemyKnightの動き処理


        // ステータス取得用変数
        [SerializeField] private EnemyStatus status;

        // 中心座標を取得する変数
        [SerializeField] private GameObject center = null;

        // 回転用変数
        [SerializeField, Tooltip("出現する位置")]   private float angle       =   0.0f;
        [SerializeField, Tooltip("中心からの距離")] private float radius      =   2.0f;
        [SerializeField, Tooltip("中心からの距離")] private float returnSpeed = 0.003f;

        private float speed;


        void Start()
        {
            this.speed = status.speed;
        }

        void Update()
        {
            // メソッド呼び出し
            Move();
            RotateDefalt();
        }


        /// <summary>
        /// 移動処理
        /// </summary>
        private void Move()
        {
            // position変更
            this.transform.position = RotateAroundZ(this.center.transform.position, this.angle, this.radius);

            // 移動するスピードを設定
            this.angle -= this.speed;

            // 中心座標まで向かう
            radius -= returnSpeed;
        }

        /// <summary>
        /// Z軸回転処理
        /// </summary>
        /// <param name="original_position"></param>
        /// <param name="angle"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        static Vector3 RotateAroundZ(Vector3 original_position, float angle, float radius)
        {
            // 中心座標を代入
            Vector3 v = original_position;

            v.y += radius;
            float a = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(a) * v.x - Mathf.Sin(a) * v.y;
            float y = Mathf.Sin(a) * v.x + Mathf.Cos(a) * v.y;
            float z = v.z;

            return new Vector3(x, y, z);


        }


        private void RotateDefalt()
        {
            transform.Rotate(0, 0, 5f);
        }
    }
}
