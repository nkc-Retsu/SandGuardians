using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class PlayerStatus : MonoBehaviour,IStatusGettable
    {
        // ステータステーブル[ステータスレベル] がステータスになる

        private int power = 0;
        private float speed = 0;
        private float shotInterval = 0;
        private float shotSpeed = 0;

        [SerializeField] private bool redFlg = false;

        [SerializeField] private bool debugFlg = false;

        [SerializeField] private int dbgPowerLvl = 0;
        [SerializeField] private int dbgSpeedLvl = 0;
        [SerializeField] private int dbgShotIntervalLvl = 0;
        [SerializeField] private int dbgShotSpeedLvl = 0;

        [SerializeField] private int[] powerTbl = new int[10]{ 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        [SerializeField] private float[] speedTbl = new float[10] { 3.5f, 4f, 4.5f, 5f, 5.5f, 6f, 6.5f, 7f, 7.5f, 8f };
        [SerializeField] private float[] shotIntervalTbl = new float[10]{ 0.3f,0.275f, 0.25f, 0.225f, 0.2f, 0.175f, 0.15f, 0.125f, 0.1f, 0.075f };
        [SerializeField] private float[] shotSpeedTbl = new float[10] { 4f, 4.5f, 5f, 5.5f, 6f, 6.5f, 7f, 7.5f, 8f, 8.5f };

        private int spAttackType = 1;

        private StatusChanger statusChanger;
        private ILevelGettable iLevelGettable;
        private ISpAttackTypeGettable iSpAttackTypeGettable;

        private SpecialAttack_Laser spAttack_Laser;
        private SpecialAttack_Spread spAttack_Spread;

        enum SPECIAL
        {
            LASER,
            SPREAD,
            SHIELD,
            COUNT
        }

        private void Awake()
        {
            iLevelGettable = new StatusChanger();

            power = powerTbl[iLevelGettable.GetPowerLevel()];
            speed = speedTbl[iLevelGettable.GetSpeedLevel()];
            shotInterval = shotIntervalTbl[iLevelGettable.GetShotIntervalLevel()];
            shotSpeed = shotSpeedTbl[iLevelGettable.GetShotSpeedLevel()];

            if(debugFlg)
            {
                power = powerTbl[dbgPowerLvl];
                speed = speedTbl[dbgSpeedLvl];
                shotInterval = shotIntervalTbl[dbgShotIntervalLvl];
                shotSpeed = shotSpeedTbl[dbgShotSpeedLvl];
            }

            if (gameObject.name == "Player_Red")
            {
                redFlg = true;
            }

            iSpAttackTypeGettable = new SpecialAttackChanger();
            spAttackType = (redFlg) ? iSpAttackTypeGettable.GetSpAttackType_Red() : iSpAttackTypeGettable.GetSpAttackType_Blue();

            // 必殺技の設定
            switch (spAttackType)
            {
                case ((int)SPECIAL.LASER):
                    gameObject.AddComponent<SpecialAttack_Laser>();
                    break;
                case ((int)SPECIAL.SPREAD):
                    gameObject.AddComponent<SpecialAttack_Spread>();
                    break;
                case ((int)SPECIAL.SHIELD):
                    gameObject.AddComponent<SpecialAttack_Shield>();
                    break;
                default:
                    break;
            }
        }

        public int GetDamage()
        {
            return power;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public float GetShotInterval()
        {
            return shotInterval;
        }

        public float GetShotSpeed()
        {
            return shotSpeed;
        }
    }
}