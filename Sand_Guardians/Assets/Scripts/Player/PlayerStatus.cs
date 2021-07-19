using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class PlayerStatus : MonoBehaviour
    {
        private int bulletDamage = 0;
        private float speed = 0;
        private float shotSpan = 0;
        private float shotSpeed = 0;

        private int bulletDamage_State = 0;
        private int speed_State = 0;
        private int shotSpan_State = 0;
        private int shotSpeed_State = 0;

        private int[] bulletDamageTbl = new int[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private float[] speedTbl = new float[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private float[] shotSpanTbl = new float[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private float[] shotSpeedTbl = new float[10]{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        private int spAttackType = 0;

        private SpecialAttack_Laser spAttack_Laser;
        private SpecialAttack_Spread spAttack_Spread;

        enum SPECIAL
        {
            LASER,
            SPREAD,
            COUNT
        }

        private void Awake()
        {
            bulletDamage = bulletDamageTbl[bulletDamage_State];
            speed = speedTbl[speed_State];
            shotSpan = shotSpanTbl[shotSpan_State];
            shotSpeed = shotSpeedTbl[shotSpeed_State];

            switch(spAttackType)
            {
                case ((int)SPECIAL.LASER):
                    gameObject.AddComponent<SpecialAttack_Laser>();
                    break;
                case ((int)SPECIAL.SPREAD):
                    gameObject.AddComponent<SpecialAttack_Spread>();
                    break;
            }

        }
    }
}