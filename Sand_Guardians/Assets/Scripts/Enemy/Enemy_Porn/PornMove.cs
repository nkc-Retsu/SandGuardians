using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class PornMove : MonoBehaviour
    {
        [SerializeField] EnemyStatus status;
        [SerializeField] private GameObject gantz;

        // �ړ������p�ϐ�
        Vector3 enemyPos;
        Vector3 gantzPos;
        Vector3 moveDir;


        // Start is called before the first frame update
        void Start()
        {
            //status = GetComponent<EnemyStatus>();
            gantz = GameObject.Find("Gantz");

            // �ړ��p�̏����擾
            enemyPos = transform.position;
            gantzPos = gantz.transform.position;
            // Enemy�̕������擾
            moveDir = gantzPos - enemyPos;

        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }



        private void Move()
        {
            // Enemy�̊p�x���擾
            float rotate = Mathf.Atan2(moveDir.y , moveDir.x);

            // Enemy���ړ����鏈��
            transform.position += moveDir.normalized * status.speed * Time.deltaTime;

            // Enemy�̌�����ς���
            if (enemyPos.x > 0 && enemyPos.y > 0)
            {
                
            }
            //else if()
        }
    }

}
