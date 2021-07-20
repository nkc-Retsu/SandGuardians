using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Bridge;

public class StatusChanger : MonoBehaviour, ILevelGettable,IAddExp
{
    enum STATUS
    {
        POWER,
        SHOT_SPEED,
        SHOT_INTERVAL,
        BOOSTER_SPEED,
        NUM
    }

    [SerializeField] private GameObject cursorObj;
    private static int exp = 0;
    [SerializeField] private Text expTxt;

    private int stateNum;

    public static int powerLvl = 0;
    private static int shotSpeedLvl = 0;
    private static int shotIntervalLvl = 0;
    private static int speedLvl = 0;

    [SerializeField] private GameObject[] powerCellArr = new GameObject[10];
    [SerializeField] private GameObject[] shotSpeedCellArr = new GameObject[10];
    [SerializeField] private GameObject[] shotIntervalCellArr = new GameObject[10];
    [SerializeField] private GameObject[] speedCellArr = new GameObject[10];

    [SerializeField] private Text[] useExpTxt;

    [SerializeField] private int[] useExpTable = new int[9] { 1000, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 9000 };

    public int GetPowerLevel() { return powerLvl; }
    public int GetShotSpeedLevel() { return shotSpeedLvl; }
    public int GetShotIntervalLevel() { return shotIntervalLvl; }
    public int GetSpeedLevel() { return speedLvl; }

    public void AddExp(int point)
    {
        exp += point;
    }


    private void Start()
    {
        expTxt.text = exp.ToString();


        useExpTxt[0].text = useExpTable[powerLvl].ToString();
        useExpTxt[1].text = useExpTable[shotSpeedLvl].ToString();
        useExpTxt[2].text = useExpTable[shotIntervalLvl].ToString();
        useExpTxt[3].text = useExpTable[speedLvl].ToString();


        CellArrActive(powerLvl, powerCellArr);
        CellArrActive(shotSpeedLvl, shotSpeedCellArr);
        CellArrActive(shotIntervalLvl, shotIntervalCellArr);
        CellArrActive(speedLvl, speedCellArr);
    }

    private void Update()
    {
        StateChange();

        if(Input.GetKeyDown(KeyCode.F12))
        {
            DebugExpSet();
        }
    }

    // デバッグ用
    private void DebugExpSet()
    {
        exp += 10000;
        expTxt.text = exp.ToString();
    }

    private void StateChange()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (stateNum != 0)
            { 
                stateNum--;
                stateNum = (stateNum + (int)STATUS.NUM) % (int)STATUS.NUM;
                cursorObj.transform.position -= new Vector3(0, -1.48f, 0);
            }

        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(stateNum!=3)
            {
                stateNum++;
                stateNum = (stateNum + (int)STATUS.NUM) % (int)STATUS.NUM;
                cursorObj.transform.position -= new Vector3(0, 1.48f, 0);
            }

        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StatusUpDown(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StatusUpDown(false);
        }
    }

    private void StatusUpDown(bool isIncrease)
    {
        int i = (isIncrease) ? 1 : -1;

        switch (stateNum)
        {
            case (int)STATUS.POWER:
                if (isIncrease && exp < useExpTable[powerLvl]) break;
                if (!isIncrease && powerLvl == 0) break;

                powerLvl += i;
                powerLvl = Mathf.Clamp(powerLvl, 0, 9);
                ExpChange(isIncrease, powerLvl);
                CellArrActive(powerLvl, powerCellArr);
                useExpTxt[0].text = useExpTable[powerLvl].ToString();
                break;

            case (int)STATUS.SHOT_SPEED:
                if (isIncrease && exp < useExpTable[shotSpeedLvl]) break;
                if (!isIncrease && shotSpeedLvl == 0) break;

                shotSpeedLvl += i;
                shotSpeedLvl = Mathf.Clamp(shotSpeedLvl, 0, 9);
                ExpChange(isIncrease, shotSpeedLvl);
                CellArrActive(shotSpeedLvl, shotSpeedCellArr);
                useExpTxt[1].text = useExpTable[shotSpeedLvl].ToString();
                break;

            case (int)STATUS.SHOT_INTERVAL:
                if (isIncrease && exp < useExpTable[shotIntervalLvl]) break;
                if (!isIncrease && shotIntervalLvl == 0) break;

                shotIntervalLvl += i;
                shotIntervalLvl = Mathf.Clamp(shotIntervalLvl, 0, 9);
                ExpChange(isIncrease, shotIntervalLvl);
                CellArrActive(shotIntervalLvl, shotIntervalCellArr);
                useExpTxt[2].text = useExpTable[shotIntervalLvl].ToString();
                break;

            case (int)STATUS.BOOSTER_SPEED:
                if (isIncrease && exp < useExpTable[speedLvl]) break;
                if (!isIncrease && speedLvl == 0) break;

                speedLvl += i;
                speedLvl = Mathf.Clamp(speedLvl, 0, 9);
                ExpChange(isIncrease, speedLvl);
                CellArrActive(speedLvl, speedCellArr);
                useExpTxt[3].text = useExpTable[speedLvl].ToString();
                break;

            default:
                break;
        }
    }

    private void CellArrActive(int lvl,GameObject[] arr)
    {
        for(int i=0;i<=lvl;++i)
        {
            arr[i].SetActive(true);
        }

        for(int i=9;i>lvl;--i)
        {
            arr[i].SetActive(false);
        }
    }

    private void ExpChange(bool isIncrease,int afterLvl)
    {
        if(isIncrease)
        {
            exp -= useExpTable[afterLvl - 1];
        }
        else
        {
            exp += useExpTable[afterLvl];
        }

        expTxt.text = exp.ToString();
    }

}
