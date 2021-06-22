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

        private int hp;

        private void Start()
        {
            this.hp = status.hp;
        }

        /// <summary>
        /// HP�̊�{����
        /// </summary>
        private void HpDirector()
        {
            if (this.hp <= 0)
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// �_���[�W���󂯂����̃C���^�[�t�F�[�X����
        /// </summary>
        /// <param name="damage"></param>
        public void ToEnemyAttack(int damage)
        {
            this.hp -= damage;
            Debug.Log(hp);
            HpDirector();
        }

        
    }

}
