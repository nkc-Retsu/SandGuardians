using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#pragma warning disable 649
namespace Enemy
{
    public class KnightMove : MonoBehaviour
    {
        // EnemyKnight�̓�������


        // �X�e�[�^�X�擾�p�ϐ�
        [SerializeField] private EnemyStatus status;

        // ���S���W���擾����ϐ�
        [SerializeField] private GameObject center = null;

        // ��]�p�ϐ�
        [SerializeField, Tooltip("�o������ʒu")]   private float angle       =   0.0f;
        [SerializeField, Tooltip("���S����̋���")] private float radius      =   2.0f;
        [SerializeField, Tooltip("���S����̋���")] private float returnSpeed = 0.003f;

        private float speed;


        void Start()
        {
            this.speed = status.speed;
        }

        void Update()
        {
            // ���\�b�h�Ăяo��
            Move();
            RotateDefalt();
        }


        /// <summary>
        /// �ړ�����
        /// </summary>
        private void Move()
        {
            // position�ύX
            this.transform.position = RotateAroundZ(this.center.transform.position, this.angle, this.radius);

            // �ړ�����X�s�[�h��ݒ�
            this.angle -= this.speed;

            // ���S���W�܂Ō�����
            radius -= returnSpeed;
        }

        /// <summary>
        /// Z����]����
        /// </summary>
        /// <param name="original_position"></param>
        /// <param name="angle"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        static Vector3 RotateAroundZ(Vector3 original_position, float angle, float radius)
        {
            // ���S���W����
            Vector3 v = original_position;

            v.y += radius;
            float a = angle * Mathf.Deg2Rad;
            float x = Mathf.Cos(a) * v.x - Mathf.Sin(a) * v.y;
            float y = Mathf.Sin(a) * v.x + Mathf.Cos(a) * v.y;
            float z = v.z;

            return new Vector3(x, y, z);


        }


        private void RotateDefalt()
        {
            transform.Rotate(0, 0, 5f);
        }
    }
}
