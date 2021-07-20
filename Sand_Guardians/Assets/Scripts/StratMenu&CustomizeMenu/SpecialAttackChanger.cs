using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;
using DG.Tweening;

public class SpecialAttackChanger : MonoBehaviour,ISpAttackTypeGettable
{
    enum SPECIAL_ATTACK
    {
        LASER,
        SPREAD,
        SHIELD,
        COUNT
    }

    private static int spAttackType_Red = 0;
    private static int spAttackType_Blue = 0;

    private bool isSelectRed = true;
    [SerializeField] private GameObject cursorObj; // カーソルのゲームオブジェクト
    [SerializeField] private Vector3 cursorPos_Red;
    [SerializeField] private Vector3 cursorPos_Blue;

    [SerializeField] private GameObject iconGroup_Red;
    [SerializeField] private GameObject iconGroup_Blue;

    private Vector3 iconMoveVec = new Vector3(0, 3, 0);

    private bool inputFlg = true;

    private void Awake()
    {
        //if(PlayerPrefs.HasKey("spAttackType_Red") || PlayerPrefs.HasKey("spAttackType_Blue"))
        //{
        //    Load();
        //}
    }

    void Start()
    {
        if (spAttackType_Red == 1) iconGroup_Red.transform.position += iconMoveVec;
        else if (spAttackType_Red == 2) iconGroup_Red.transform.position -= iconMoveVec;

        if (spAttackType_Blue == 1) iconGroup_Blue.transform.position += iconMoveVec;
        else if (spAttackType_Blue == 2) iconGroup_Blue.transform.position -= iconMoveVec;
    }

    void Update()
    {
        if (!inputFlg) return;

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
            inputFlg = false;
            spAttackType_Red += num;
            iconGroup_Red.transform.DOMove(iconGroup_Red.transform.position + (num * iconMoveVec), 0.5f)
                .OnComplete(InputFlgChange);
            spAttackType_Red = (spAttackType_Red + (int)SPECIAL_ATTACK.COUNT) % (int)SPECIAL_ATTACK.COUNT;
            Debug.Log("red" + spAttackType_Red);
        }
        else
        {
            // 青
            inputFlg = false;
            spAttackType_Blue += num;
            iconGroup_Blue.transform.DOMove(iconGroup_Blue.transform.position+(num * iconMoveVec), 0.5f)
                .OnComplete(InputFlgChange);

            spAttackType_Blue = (spAttackType_Blue + (int)SPECIAL_ATTACK.COUNT) % (int)SPECIAL_ATTACK.COUNT;
            Debug.Log("blue" + spAttackType_Blue);
        }

        //Save();
    }

    private void InputFlgChange()
    {
        inputFlg = true;
    }

    public int GetSpAttackType_Red()
    {
        return spAttackType_Red;
    }

    public int GetSpAttackType_Blue()
    {
        return spAttackType_Blue;
    }

    //private void Load()
    //{
    //    spAttackType_Red = PlayerPrefs.GetInt("spAttackType_Red");
    //    spAttackType_Blue = PlayerPrefs.GetInt("spAttackType_Blue");
    //}

    //private void Save()
    //{
    //    PlayerPrefs.SetInt("spAttackType_Red", spAttackType_Red);
    //    PlayerPrefs.SetInt("spAttackType_Blue", spAttackType_Blue);
    //}
}
