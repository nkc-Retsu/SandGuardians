using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    void Update()
    {
        transform.position += transform.up.normalized * speed * Time.deltaTime;
    }
}
