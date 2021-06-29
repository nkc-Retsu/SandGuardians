using Bridge;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyCore : MonoBehaviour, IP2EAttack
    {
        // Enemy�̊�{����

        // �X�e�[�^�X�擾�p�ϐ�
        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject bombObj;

        // ����php�ϐ�
        private int hp;

        private bool damgeFlg = false;
        
        public bool DamageFlg
        {
            get
            {
                return damgeFlg;
            }
            set
            {
                damgeFlg = value;
            }
        }
        

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
                // �X�R�A�Ƀ|�C���g�����Z
                ScoreDirector.scorePoint += status.enemyPoint;

                // �|����Enemy��++���Ă��� 
                ScoreDirector.enemyBreak++;

                // �����I�u�W�F�N�g�𐶐�
                Instantiate(bombObj).transform.position = transform.position;

                // �G������
                Destroy(gameObject,0.2f);
            }
        }

        /// <summary>
        /// �_���[�W���󂯂����̃C���^�[�t�F�[�X����
        /// </summary>
        /// <param name="damage"></param>
        public void ToEnemyAttack(int damage, ref bool isDead)
        {
            // hp��damage������
            this.hp -= damage;

            if (hp <= 0) isDead = true;
            else isDead = false;

            // HP���\�b�h�Ăяo��
            HpDirector();

            damgeFlg = true;
        }


    }

}
