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
        private Vector3 offsetPos; // î≠éÀà íu
        private float offsetRate = 0.2f; // î≠éÀà íuí≤êÆóp

        GameObject sPManager;
        SpecialPointManager sPManager_cs;

        [SerializeField] private int useSP = 5;

        void Start()
        {
            inputer = GetComponent<IInputer>();
            sPManager = GameObject.Find("SPManager");
            sPManager_cs = sPManager.GetComponent<SpecialPointManager>();
        }

        void Update()
        {
            if(inputer.SpecialAttack_Red()) LaserBeam();
        }

        private void LaserBeam()
        {
            if (sPManager_cs.UsePoint(useSP))
            {
                offsetPos = transform.up * offsetRate;
                Instantiate(laserBeam, this.transform.position + offsetPos, Quaternion.Euler(transform.localEulerAngles));
            }
            else return;
        }
    }
}
