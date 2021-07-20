using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class SpecialAttack_Shield : MonoBehaviour
    {
        private IInputer inputer;
        private GameObject shieldObj;
        private GameObject spManager;
        private SpecialPointManager spManager_cs;
        private bool redFlg = false;

        private int useSP = 10;

        void Start()
        {
            spManager = GameObject.Find("SPManager");
            spManager_cs = spManager.GetComponent<SpecialPointManager>();

            shieldObj = (GameObject)Resources.Load("Shield");
            inputer = GetComponent<IInputer>();

            if (gameObject.name == "Player_Red")
            {
                redFlg = true;
            }

        }

        void Update()
        {
            if (redFlg)
            {
                if (inputer.SpecialAttack_Red()) Shield();
            }
            else
            {
                if (inputer.SpecialAttack_Blue()) Shield();
            }
        }

        private void Shield()
        {
            if (spManager_cs.UsePoint(useSP))
            {
                Instantiate(shieldObj).transform.position = Vector3.zero;
            }
        }
    }
}
