using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarLightMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0;
    Vector3 traPos;
    float anotherTraPosX;
    public GameObject anotherGround;
    void Update()
    {
        traPos = this.transform.position;
        anotherTraPosX = anotherGround.transform.position.x;
        transform.position += new Vector3(moveSpeed * -1, 0, 0) * Time.deltaTime;


        if (traPos.x <= -85)
        {
            this.transform.position = new Vector3(anotherTraPosX + 150, 0f, 0);
        }
    }
}
