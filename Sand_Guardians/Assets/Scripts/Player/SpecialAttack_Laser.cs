using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class SpecialAttack_Laser : MonoBehaviour
    {
        IInputer inputer;

        private bool redFlg = false;
        private GameObject laserBeam;
        private Vector3 offsetPos; // î≠éÀà íu
        private float offsetRate = 0.2f; // î≠éÀà íuí≤êÆóp

        GameObject sPManager;
        SpecialPointManager sPManager_cs;

        private int useSP = 5;

        private AudioSource audioSource;
        private AudioClip laserSound;

        public Sprite red;
        public Sprite blue;

        void Start()
        {
            inputer = GetComponent<IInputer>();
            sPManager = GameObject.Find("SPManager");
            sPManager_cs = sPManager.GetComponent<SpecialPointManager>();
            laserBeam = Resources.Load<GameObject>("Prefabs/LaserBeam");
            laserSound = Resources.Load<AudioClip>("SE/LaserSE");
            audioSource = GetComponent<AudioSource>();

            if (gameObject.name == "Player_Red")
            {
                redFlg = true;
            }
        }

        void Update()
        {
            if (redFlg)
            {
                laserBeam.GetComponent<SpriteRenderer>().sprite = red;
                if (inputer.SpecialAttack_Red()) LaserBeam();
            }
            else
            {
                laserBeam.GetComponent<SpriteRenderer>().sprite = blue;
                if (inputer.SpecialAttack_Blue()) LaserBeam();
            }
        }

        private void LaserBeam()
        {
            if (sPManager_cs.UsePoint(useSP))
            {
                offsetPos = transform.up * offsetRate;
                GameObject laserObj = Instantiate(laserBeam, this.transform.position + offsetPos, Quaternion.Euler(transform.localEulerAngles));
                laserObj.GetComponent<LaserBeam>().SetPlayer(gameObject);
                audioSource.PlayOneShot(laserSound);
            }
            else return;
        }
    }
}
