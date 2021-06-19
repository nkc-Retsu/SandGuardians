using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        // Enemy�̍U������

        [SerializeField] private EnemyStatus status;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            var e2GAttack = collision.gameObject.GetComponent<IE2GAttack>();

            if(e2GAttack != null)
            {
                
                e2GAttack.ToGantzAttack(status.attackPower);
                Debug.Log("Gantz�ɓ��������I");
                Destroy(gameObject);
            }
        }
    }

}
