using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class SpecialAttackChanger : MonoBehaviour,ISpAttackTypeGettable
{
    enum SPECIAL_ATTACK
    {
        LASER,
        SPREAD,
        COUNT
    }

    private static int spAttackType_Red = 0;
    private static int spAttackType_Blue = 0;

    private bool isSelectRed = true;
    [SerializeField] private GameObject cursorObj; // カーソルのゲームオブジェクト
    [SerializeField] private Vector3 cursorPos_Red;
    [SerializeField] private Vector3 cursorPos_Blue;

    void Start()
    {
        
    }

    void Update()
    {
        // 左右入力があったら選択情報を逆転（赤←→青）
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangeSelect();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Scroll(true);
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Scroll(false);
        }
    }

    private void ChangeSelect()
    {
        isSelectRed = (isSelectRed) ? false : true;


        if(isSelectRed)
        {
            cursorObj.transform.position = cursorPos_Red;
        }
        else
        {
            cursorObj.transform.position = cursorPos_Blue;
        }
    }

    private void Scroll(bool isUp)
    {
        int num = (isUp) ? -1 : 1;

        // typeの値を変更
        if(isSelectRed)
        {
            // 赤
            spAttackType_Red += num;
            spAttackType_Red = (spAttackType_Red + (int)SPECIAL_ATTACK.COUNT) % (int)SPECIAL_ATTACK.COUNT;
            //Debug.Log("red" + spAttackType_Red);
        }
        else
        {
            // 青
            spAttackType_Blue += num;
            spAttackType_Blue = (spAttackType_Blue + (int)SPECIAL_ATTACK.COUNT) % (int)SPECIAL_ATTACK.COUNT;
            //Debug.Log("blue" + spAttackType_Blue);
        }

    }

    public int GetSpAttackType_Red()
    {
        return spAttackType_Red;
    }

    public int GetSpAttackType_Blue()
    {
        return spAttackType_Blue;
    }
}
