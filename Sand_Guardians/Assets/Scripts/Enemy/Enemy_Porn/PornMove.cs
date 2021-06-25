using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 649
namespace Enemy
{
    public class PornMove : MonoBehaviour
    {

        // EnemyPorn�̓�������

        // �擾�p�ϐ�
        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject gantz;


        // �ړ������p�ϐ�
        private Vector3 enemyPos;   // Enemy�̈ʒu
        private Vector3 gantzPos;   // Gantz�̈ʒu
        private Vector3 moveDir;    // �����x�N�g��
        private float speed;        // Enemy��speed



        // Start is called before the first frame update
        void Start()
        {
            // Gantz�̃I�u�W�F�N�g���擾
            gantz = GameObject.Find("Gantz");

            // �X�e�[�^�X��speed����
            this.speed = status.speed;

            // �ړ��p�̏����擾
            enemyPos = transform.position;
            gantzPos = gantz.transform.position;

            // Enemy����Gantz�ւ̃x�N�g�����擾
            moveDir = gantzPos - enemyPos;

        }

        // Update is called once per frame
        void Update()
        {
            Move();
            Angle();
        }



        /// <summary>
        /// Enemy�̈ړ�����
        /// </summary>
        private void Move()
        {
            // Enemy���ړ����鏈��
            transform.position += moveDir.normalized * this.speed * Time.deltaTime;
        }

        /// <summary>
        /// Enemy�̕�������
        /// </summary>
        private void Angle()
        {

            // Enemy�̊p�x���擾
            float angle = (Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg) - 90.0f;

            // Enemy�̈ʒu�ɂ���Č�����ύX����
            transform.rotation = Quaternion.Euler(0f,0f,angle);

        }
    }

}
