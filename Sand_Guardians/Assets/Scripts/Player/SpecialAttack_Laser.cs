using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class SpecialAttack_Laser : MonoBehaviour
    {
        IInputer inputer;
        GameObject laserObj;
        private bool redFlg = false;
        private GameObject laserBeam;
        private Vector3 offsetPos; // î≠éÀà íu
        private float offsetRate = 0.2f; // î≠éÀà íuí≤êÆóp

        private  GameObject sPManager;
        SpecialPointManager sPManager_cs;

        private int useSP = 5;

        private AudioSource audioSource;
        [SerializeField] private AudioClip laserSound;

        [SerializeField] private Sprite red;
        [SerializeField] private Sprite blue;

        private void Awake()
        {
            laserBeam = (GameObject)Resources.Load("LaserBeam");
        }

        void Start()
        {
            inputer = GetComponent<IInputer>();
            sPManager = GameObject.Find("SPManager");
            sPManager_cs = sPManager.GetComponent<SpecialPointManager>();
            //laserBeam = Resources.Load<GameObject>("Prefabs/LaserBeam");
            audioSource = GetComponent<AudioSource>();

            laserObj = Instantiate(laserBeam, this.transform.position + offsetPos, Quaternion.Euler(transform.localEulerAngles));
            laserObj.GetComponent<SpriteRenderer>().sprite = (redFlg) ? red : blue;
            laserObj.GetComponent<LaserBeam>().SetPlayer(gameObject);
            laserObj.SetActive(false);


            if (gameObject.name == "Player_Red")
            {
                redFlg = true;
            }
        }

        void Update()
        {
            if (redFlg)
            {
                if (inputer.SpecialAttack_Red()) LaserBeam();
            }
            else
            {
                if (inputer.SpecialAttack_Blue()) LaserBeam();
            }
        }

        private void LaserBeam()
        {
            if (sPManager_cs.UsePoint(useSP))
            {
                offsetPos = transform.up * offsetRate;
                laserObj.SetActive(true);
                laserObj.transform.position = transform.position;
                laserObj.transform.localEulerAngles = transform.localEulerAngles;
                audioSource.PlayOneShot(laserSound);
            }
            else return;
        }
    }
}
