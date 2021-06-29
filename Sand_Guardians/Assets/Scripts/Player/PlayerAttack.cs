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

        private AudioSource audioSource;
        [SerializeField] AudioClip shotSound;

        void Start()
        {
            inputer = GetComponent<IInputer>();
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            timeSecondCounter -= Time.deltaTime;

            if (inputer.Attack())
            {
                if(timeSecondCounter<=0)
                {
                    Attack();
                    timeSecondCounter = attackSpan;
                }
            }

        }

        void Attack()
        {
            offsetPos = transform.up * offsetRate;
            Instantiate(bullet, this.transform.position+offsetPos, Quaternion.Euler(transform.localEulerAngles));
            audioSource.PlayOneShot(shotSound);
        }
    }
}
