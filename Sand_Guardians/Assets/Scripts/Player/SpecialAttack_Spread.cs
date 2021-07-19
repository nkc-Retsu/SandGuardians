using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class SpecialAttack_Spread : MonoBehaviour
    {
        IInputer inputer;

        [SerializeField] private bool redFlg;
        private BulletPool bulletPool;
        [SerializeField] private GameObject poolObj;

        [SerializeField] GameObject spreadBullet; // ägéUíe
        private Vector3 offsetPos; // î≠éÀà íu
        private float offsetRate = 0.2f; // î≠éÀà íuí≤êÆóp

        [SerializeField] private float angle = 0; // î≠éÀäpìx
        [SerializeField] private int shotCount = 11; // íeêî

        GameObject sPManager;
        SpecialPointManager sPManager_cs;

        [SerializeField] private int useSP = 2;

        private AudioSource audioSource;
        [SerializeField] AudioClip spreadShotSound;

        [SerializeField] private int damage = 30;

        void Start()
        {
            
            inputer = GetComponent<IInputer>();
            bulletPool = poolObj.GetComponent<BulletPool>();
            sPManager = GameObject.Find("SPManager");
            sPManager_cs = sPManager.GetComponent<SpecialPointManager>();

            audioSource = GetComponent<AudioSource>();

            angle /= shotCount;
        }

        void Update()
        {
            if (inputer.SpecialAttack_Blue()) SpreadBullet();
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
                    bullet.GetComponent<IDamageSettable>().SetDamage(damage);
                    bullet.transform.position = transform.position + offsetPos;
                    bullet.transform.localEulerAngles = rotate;
                    //Instantiate(spreadBullet, this.transform.position + offsetPos, Quaternion.Euler(rotate));
                    rotate += new Vector3(0, 0, angle);
                }

                audioSource.PlayOneShot(spreadShotSound);
            }
        }
    }
}
