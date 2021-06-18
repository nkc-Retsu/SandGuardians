using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class PornMove : MonoBehaviour
    {
        [SerializeField] EnemyStatus status;
        [SerializeField] private GameObject gantz;

        // ˆÚ“®ˆ——p•Ï”
        Vector3 enemyPos;
        Vector3 gantzPos;
        Vector3 moveDir;


        // Start is called before the first frame update
        void Start()
        {
            //status = GetComponent<EnemyStatus>();
            gantz = GameObject.Find("Gantz");

            // ˆÚ“®—p‚Ìî•ñ‚ğæ“¾
            enemyPos = transform.position;
            gantzPos = gantz.transform.position;
            // Enemy‚Ì•ûŒü‚ğæ“¾
            moveDir = gantzPos - enemyPos;

        }

        // Update is called once per frame
        void Update()
        {
            Move();
        }



        private void Move()
        {
            // Enemy‚ÌŠp“x‚ğæ“¾
            float rotate = Mathf.Atan2(moveDir.y , moveDir.x);

            // Enemy‚ªˆÚ“®‚·‚éˆ—
            transform.position += moveDir.normalized * status.speed * Time.deltaTime;

            // Enemy‚ÌŒü‚«‚ğ•Ï‚¦‚é
            if (enemyPos.x > 0 && enemyPos.y > 0)
            {
                
            }
            //else if()
        }
    }

}
