using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        // Enemyの攻撃処理

        [SerializeField] private EnemyStatus status;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            var e2GAttack = collision.gameObject.GetComponent<IE2GAttack>();

            if(e2GAttack != null)
            {
                
                e2GAttack.ToGantzAttack(status.attackPower);
                Debug.Log("Gantzに当たった！");
                Destroy(gameObject);
            }
        }
    }

}
