using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class PornMove : MonoBehaviour
    {
        [SerializeField] EnemyStatus status;
        [SerializeField] private GameObject gantz;

        // 移動処理用変数
        Vector3 enemyPos;
        Vector3 gantzPos;
        Vector3 moveDir;


        // Start is called before the first frame update
        void Start()
        {
            //status = GetComponent<EnemyStatus>();
            gantz = GameObject.Find("Gantz");

            // 移動用の情報を取得
            enemyPos = transform.position;
            gantzPos = gantz.transform.position;
            // Enemyの方向を取得
            moveDir = gantzPos - enemyPos;

        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }



        private void Move()
        {
            // Enemyの角度を取得
            float rotate = Mathf.Atan2(moveDir.y , moveDir.x);

            // Enemyが移動する処理
            transform.position += moveDir.normalized * status.speed * Time.deltaTime;

            // Enemyの向きを変える
            if (enemyPos.x > 0 && enemyPos.y > 0)
            {
                
            }
            //else if()
        }
    }

}
