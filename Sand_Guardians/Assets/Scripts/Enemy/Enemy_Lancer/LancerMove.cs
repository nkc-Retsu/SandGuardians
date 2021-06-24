using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 649
namespace Enemy
{
    public class LancerMove : MonoBehaviour
    {
        // EnemyLancer�̓�������


        // �擾�p�ϐ�
        [SerializeField] private EnemyStatus status;
        [SerializeField] private GameObject gantz;


        // �����p�ϐ�
        [SerializeField, Tooltip("�����o���܂ł̎���")] private float timeUp;
        [SerializeField, Tooltip("�~�܂�ʒu")] �@�@�@�@private float movePos;


        // �ړ������p�ϐ�
        private Vector3 enemyPos;   // Enemy�̈ʒu�ϐ�
        private Vector3 gantzPos;   // Gantz�̈ʒu�ϐ�
        private Vector3 moveDir;    // Enemy����Gantz�ւ̃x�N�g���ϐ�
        private float distance_X;   // Enemy����Gantz�܂ł�x���W
        private float distance_Y;�@ // Enemy����Gantz�܂ł�y���W
        private float time;         // ���Ԍv���p�ϐ�
        private float speed;        // Enemy�̃X�s�[�h


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
            //���\�b�h�Ăяo��
            Move();
            Angle();
        }



        /// <summary>
        /// Enemy�̈ړ�����
        /// </summary>
        private void Move()
        {
            // Enemy�̈ʒu���擾
            enemyPos = transform.position;

            // Enemy����Gantz�܂ł̋������擾
            distance_X = gantzPos.x - enemyPos.x;
            distance_Y = gantzPos.y - enemyPos.y;


            // Enemy���ړ����鏈��
            transform.position += moveDir.normalized * this.speed * Time.deltaTime;


            // Gantz�̋߂��ɂȂ�ƒ�~����
            if (Mathf.Abs(distance_X) <= movePos && Mathf.Abs(distance_Y) <= movePos)
            {
                // �ړ����x��0�ɂ���
                this.speed = 0f;

                // ���Ԍv���J�n
                time += Time.deltaTime;
            }

            // ���Ԃœ����o��
            if (time > timeUp) this.speed = 5f;

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
