using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class PlayerSpecialAttack : MonoBehaviour
    {
        IInputer inputer;

        [SerializeField] GameObject spreadBullet; // ägéUíe
        private Vector3 offsetPos; // î≠éÀà íu
        private float offsetRate = 0.2f; // î≠éÀà íuí≤êÆóp

        [SerializeField] private float angle = 0; // î≠éÀäpìx
        [SerializeField] private int shotCount = 11; // íeêî

        void Start()
        {
            inputer = GetComponent<IInputer>();
            angle /= shotCount;
        }

        void Update()
        {
            if (inputer.SpecialAttack()) SpreadBullet();
        }
        
        private void SpreadBullet()
        {
            offsetPos = transform.up * offsetRate;
            Vector3 rotate = transform.localEulerAngles - new Vector3(0, 0, angle * (shotCount / 2));

            for (int i=0;i<shotCount;++i)
            {
                Instantiate(spreadBullet, this.transform.position + offsetPos, Quaternion.Euler(rotate));
                rotate +=new Vector3(0,0, angle);
            }
        }
    }
}
