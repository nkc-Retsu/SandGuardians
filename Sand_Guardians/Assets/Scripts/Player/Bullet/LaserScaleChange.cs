using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScaleChange : MonoBehaviour
{
    private bool isAppearing;
    private bool isExpanding = false;
    [SerializeField] private float scaleChangeRate = 3f;
    float timeSecondCounter = 0;
    [SerializeField] private float scaleRate = 3f;

    [SerializeField] private float scaleChangeTime = 0.5f;
    private float timeCounter2 = 0;

    void Start()
    {
        
    }

    void Update()
    {
        timeSecondCounter += Time.deltaTime;
        timeCounter2 += Time.deltaTime;

        if (timeCounter2 < 0.5f)
        {
            if (timeSecondCounter > scaleChangeTime)
            {
                if (isExpanding) isExpanding = false;
                else isExpanding = true;

                timeSecondCounter = 0;
            }

            if (isExpanding)
            {
                transform.localScale += new Vector3(3f * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.localScale -= new Vector3(3f * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            transform.localScale -= new Vector3(3f * Time.deltaTime, 0, 0);
        }
    }
}
