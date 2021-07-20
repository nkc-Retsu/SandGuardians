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

    void Start()
    {
        mainCameraObj.transform.position = new Vector3(0,0,-10);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && isStatusChangeState)
        {
            mainCameraObj.transform.DOMove(specialChangeCameraPos, cameraMoveSecond);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            mainCameraObj.transform.DOMove(statusChangeCameraPos, cameraMoveSecond);
        }
    }
}
