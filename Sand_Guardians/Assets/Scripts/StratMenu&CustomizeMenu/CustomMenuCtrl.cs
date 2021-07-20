using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomMenuCtrl : MonoBehaviour
{
    [SerializeField] private GameObject mainCameraObj;
    private bool isStatusChangeState = true;

    [SerializeField] private float cameraMoveSecond = 0.5f;

    [SerializeField] private Vector3 statusChangeCameraPos;
    [SerializeField] private Vector3 specialChangeCameraPos;

    [SerializeField] private GameObject statusChanger;
    [SerializeField] private GameObject spAttackChanger;

    void Start()
    {
        mainCameraObj.transform.position = new Vector3(0,0,-10);
        spAttackChanger.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && isStatusChangeState)
        {
            mainCameraObj.transform.DOMove(specialChangeCameraPos, cameraMoveSecond);
            statusChanger.SetActive(false);
            spAttackChanger.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            mainCameraObj.transform.DOMove(statusChangeCameraPos, cameraMoveSecond);
            statusChanger.SetActive(true);
            spAttackChanger.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            FadeManager.Instance.LoadScene("StartMenuScene", 0.5f);
        }
    }
}
