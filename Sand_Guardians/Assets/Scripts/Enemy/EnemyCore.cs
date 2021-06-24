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

        // ����php�ϐ�
        private int hp;



        private void Start()
        {
            // �X�e�[�^�X��hp����
            this.hp = status.hp;
        }

        /// <summary>
        /// HP�̊�{����
        /// </summary>
        private void HpDirector()
        {
            // �̗͂�0�ɂȂ��������
            if (this.hp <= 0)
            {
                ScoreDirector.scorePoint += status.enemyPoint;
                Debug.Log(ScoreDirector.scorePoint);
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
            HpDirector();
        }

        
    }

}
