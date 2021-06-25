using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class PlayerSpecialAttack_Red : MonoBehaviour
    {
        IInputer inputer;

        [SerializeField] GameObject laserBeam;
        private Vector3 offsetPos; // ���ˈʒu
        private float offsetRate = 0.2f; // ���ˈʒu�����p

        void Start()
        {
            inputer = GetComponent<IInputer>();
        }

        void Update()
        {
            if(inputer.SpecialAttack_Red()) LaserBeam();
        }
        

        private void LaserBeam()
        {
            offsetPos = transform.up * offsetRate;
            Instantiate(laserBeam, this.transform.position + offsetPos, Quaternion.Euler(transform.localEulerAngles));
        }
    }
}
