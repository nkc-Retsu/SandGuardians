using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private IInputer inputer;

        [SerializeField] private GameObject bullet;
        private Vector3 offsetPos;
        private float offsetRate = 0.2f;

        private float timeSecondCounter = 0;
        [SerializeField] private float attackSpan = 0.2f;

        void Start()
        {
            inputer = GetComponent<IInputer>();
        }

        void Update()
        {
            timeSecondCounter += Time.deltaTime;

            if (timeSecondCounter > attackSpan)
            {
                if (inputer.Attack()) Attack();
                timeSecondCounter = 0;
            }

        }

        void Attack()
        {
            offsetPos = transform.up * offsetRate;
            Instantiate(bullet, this.transform.position+offsetPos, Quaternion.Euler(transform.localEulerAngles));
        }
    }
}
