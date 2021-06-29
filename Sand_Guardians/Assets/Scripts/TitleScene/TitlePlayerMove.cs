using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayerMove : MonoBehaviour
{
    [SerializeField] bool thisIsHigh = true;
    float timer = 0;
    float LimitTimer = 5f;
    float speed = 5;
    float highPos = -1;
    float lowPos = -3;
    float shotSpan = 0.05f;
    float renshaTimer = 0;
    SpriteRenderer spRe;
    [SerializeField] GameObject bullet;
    void Start()
    {
        spRe = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Rot();
        Shot();
    }

    private void Rot()
    {
        timer += Time.deltaTime;
        if (timer >= LimitTimer)
        {

            if (thisIsHigh == false)//‰º‚É‚¢‚é
            {
                transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
                spRe.sortingOrder = 0;
                if (transform.position.y >= highPos)
                {
                    timer = 0;
                    thisIsHigh = true;
                }
            }
            if (thisIsHigh == true)//‰º‚É‚¢‚é
            {
                transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
                spRe.sortingOrder = 1;
                if (transform.position.y <= lowPos)
                {
                    timer = 0;
                    thisIsHigh = false;
                }
            }
        }
    }

    private void Shot()
    {
        renshaTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.X))
        {
            if(renshaTimer <= 0)
            {
                Instantiate(bullet, this.transform.position, Quaternion.Euler(transform.localEulerAngles));
                renshaTimer = shotSpan;
            }
        }
    }
}
