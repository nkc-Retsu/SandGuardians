using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyCore : MonoBehaviour,IP2EAttack
    {
        // Enemy�̊�{����

        // �X�e�[�^�X�擾�p�ϐ�
        [SerializeField] private EnemyStatus status;


        /// <summary>
        /// HP�̊�{����
        /// </summary>
        private void HpDirector()
        {
            if (status.hp <= 0) Destroy(gameObject);
        }

        /// <summary>
        /// �_���[�W���󂯂����̃C���^�[�t�F�[�X����
        /// </summary>
        /// <param name="damage"></param>
        public void ToEnemyAttack(int damage)
        {
            status.hp = -damage;
        }

        
    }

}
