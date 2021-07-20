using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // ���Ԃŏ�����V�[���h

    [SerializeField] private float appearTime = 10f;
    private float timeCounter = 0;
    void Start()
    {
        timeCounter = 0;
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter>appearTime)
        {
            Destroy(gameObject);
        }
    }
}
