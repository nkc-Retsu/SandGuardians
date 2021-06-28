using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBulletMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += new Vector3(10, 0, 0) * Time.deltaTime;
    }
    
}
