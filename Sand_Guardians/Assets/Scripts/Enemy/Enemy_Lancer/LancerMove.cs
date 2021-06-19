using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class LancerMove : MonoBehaviour
    {

        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject gantz;


        // �ړ������p�ϐ�
        private Vector3 enemyPos;
        private Vector3 gantzPos;
        private Vector3 moveDir;



        // Start is called before the first frame update
        void Start()
        {
            // Gantz�̃I�u�W�F�N�g���擾
            gantz = GameObject.Find("Gantz");

            // �ړ��p�̏����擾
            enemyPos = transform.position;
            gantzPos = gantz.transform.position;

            // Enemy����Gantz�ւ̃x�N�g�����擾
            moveDir = gantzPos - enemyPos;

        }

        // Update is called once per frame
        void Update()
        {
            //���\�b�h�Ăяo��
            Move();
            Angle();
        }



        /// <summary>
        /// Enemy�̈ړ�����
        /// </summary>
        private void Move()
        {
            // Enemy���ړ����鏈��
            transform.position += moveDir.normalized * status.speed * Time.deltaTime;

            //if ()
            //{

            //}
        }

        /// <summary>
        /// Enemy�̕�������
        /// </summary>
        private void Angle()
        {

            // Enemy�̊p�x���擾
            float angle = (Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg) - 90.0f;

            // Enemy�̈ʒu�ɂ���Č�����ύX����
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

        }
    }

}
