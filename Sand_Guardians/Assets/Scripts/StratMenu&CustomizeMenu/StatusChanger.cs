using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChanger : MonoBehaviour
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
    private int exp = 0;
    private int stateNum;

    private void Start()
    {

    }

    private void Update()
    {
        StateChange();
    }

    // デバッグ用
    private void StateChange()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            stateNum--;
            stateNum = (stateNum + (int)STATUS.NUM) % (int)STATUS.NUM;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            stateNum++;
            stateNum = (stateNum + (int)STATUS.NUM) % (int)STATUS.NUM;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (stateNum)
            {
                case (int)STATUS.POWER:
                    break;

                case (int)STATUS.SHOT_SPEED:
                    break;

                case (int)STATUS.SHOT_INTERVAL:
                    break;

                case (int)STATUS.BOOSTER_SPEED:
                    break;
                default:
                    break;
            }
        }
    }
}
