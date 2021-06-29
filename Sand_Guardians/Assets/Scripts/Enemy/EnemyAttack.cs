using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 649
namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        // Enemy�̍U������

        // �X�e�[�^�X�擾�p�ϐ�
        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject bomb;

        private void Start()
        {
        }


        /// <summary>
        /// �����蔻��
        /// </summary>
        /// <param name="collision"></param>
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // collision�̃R���|�[�l���g���擾
            var e2GAttack = collision.gameObject.GetComponent<IE2GAttack>();

            if (e2GAttack != null)
            {
                // �C���^�[�t�F�[�X�Ăяo��
                e2GAttack.ToGantzAttack(status.attackPower);
                
                // Object������
                Destroy(gameObject);

                // Effect�𐶐�
                Instantiate(bomb).transform.position = transform.position;
            }
        }
    }

}
