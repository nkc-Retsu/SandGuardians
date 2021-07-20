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
        private Vector3 offsetPos; // 発射位置
        private float offsetRate = 0.2f; // 発射位置調整用

        private  GameObject sPManager;
        SpecialPointManager sPManager_cs;

        private int useSP = 5; // 使用ポイント

        private AudioSource audioSource;
        [SerializeField] private AudioClip laserSound;

        private Sprite red;
        private Sprite blue;

        private void Awake()
        {
            //red = (Sprite)Resources.Load("Laser[0]");
            //blue = (Sprite)Resources.Load("Laser[1]");

        }

        void Start()
        {
            if (gameObject.name == "Player_Red")
            {
                redFlg = true;
            }

            inputer = GetComponent<IInputer>();
            sPManager = GameObject.Find("SPManager");
            sPManager_cs = sPManager.GetComponent<SpecialPointManager>();
            //laserBeam = Resources.Load<GameObject>("Prefabs/LaserBeam");
            audioSource = GetComponent<AudioSource>();


            laserBeam = (redFlg) ? (GameObject)Resources.Load("LaserBeam_Red") : (GameObject)Resources.Load("LaserBeam_Blue");


            laserObj = Instantiate(laserBeam, this.transform.position + offsetPos, Quaternion.Euler(transform.localEulerAngles));
            //laserObj.GetComponent<SpriteRenderer>().sprite = (redFlg) ? red : blue;
            laserObj.GetComponent<LaserBeam>().SetPlayer(gameObject);
            laserObj.SetActive(false);

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
                //laserObj.GetComponent<SpriteRenderer>().sprite = (redFlg) ? red : blue;
                laserObj.transform.position = transform.position;
                laserObj.transform.localEulerAngles = transform.localEulerAngles;
                audioSource.PlayOneShot(laserSound);
            }
            else return;
        }
    }
}
