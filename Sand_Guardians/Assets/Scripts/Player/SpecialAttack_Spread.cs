using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class SpecialAttack_Spread : MonoBehaviour
    {
        IInputer inputer;

        private bool redFlg = false;
        private BulletPool bulletPool;
        private GameObject poolObj;

        private Vector3 offsetPos; // î≠éÀà íu
        private float offsetRate = 0.2f; // î≠éÀà íuí≤êÆóp

        private float angle = 60; // î≠éÀäpìx
        [SerializeField] private int shotCount = 11; // íeêî

        GameObject sPManager;
        SpecialPointManager sPManager_cs;

        [SerializeField] private int useSP = 2;

        private AudioSource audioSource;
        [SerializeField] AudioClip spreadShotSound;

        void Start()
        {
            poolObj = GameObject.Find("PoolObj");

            if (gameObject.name == "Player_Red")
            {
                redFlg = true;
            }

            inputer = GetComponent<IInputer>();
            bulletPool = poolObj.GetComponent<BulletPool>();
            sPManager = GameObject.Find("SPManager");
            sPManager_cs = sPManager.GetComponent<SpecialPointManager>();

            audioSource = GetComponent<AudioSource>();

            angle /= shotCount;
        }

        void Update()
        {
            if (redFlg)
            {
                if (inputer.SpecialAttack_Red()) SpreadBullet();
            }
            else
            {
                if (inputer.SpecialAttack_Blue()) SpreadBullet();
            }
        }

        private void SpreadBullet()
        {
            if (sPManager_cs.UsePoint(useSP))
            {

                offsetPos = transform.up * offsetRate;
                Vector3 rotate = transform.localEulerAngles - new Vector3(0, 0, angle * (shotCount / 2));

                for (int i = 0; i < shotCount; ++i)
                {
                    GameObject bullet;
                    bullet = (redFlg) ? bulletPool.GetRedBullet() : bulletPool.GetBlueBullet();
                    bullet.SetActive(true);
                    bullet.transform.position = transform.position + offsetPos;
                    bullet.transform.localEulerAngles = rotate;
                    //Instantiate(spreadBullet, this.transform.position + offsetPos, Quaternion.Euler(rotate));
                    rotate += new Vector3(0, 0, angle);
                    // î≠éÀäpÇâ¡éZ
                }

                audioSource.PlayOneShot(spreadShotSound);
            }
        }
    }
}
