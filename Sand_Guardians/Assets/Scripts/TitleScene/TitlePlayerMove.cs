using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayerMove : MonoBehaviour
{
    [SerializeField] bool thisIsHigh = true;
    float timer = 0;
    float LimitTimer = 5;
    float speed = 3;
    float highPos = -1;
    float lowPos = -3;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= LimitTimer)
        {
            if(thisIsHigh == false)//下にいる
            {
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
                if(transform.position.y >= highPos)
                {
                    timer = 0;
                    thisIsHigh = true;
                }
            }
            if(thisIsHigh == true)//下にいる
            {
                transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
                if(transform.position.y <= lowPos)
                {
                    timer = 0;
                    thisIsHigh = false;
                }
            }
        }
    }
}
