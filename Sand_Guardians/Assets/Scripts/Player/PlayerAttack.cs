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

        void Start()
        {
            inputer = GetComponent<IInputer>();
        }

        void Update()
        {
            if(inputer.Attack()) Attack();

        }

        void Attack()
        {
            offsetPos = transform.up * offsetRate;
            Instantiate(bullet, this.transform.position+offsetPos, Quaternion.Euler(transform.localEulerAngles));
        }
    }
}
