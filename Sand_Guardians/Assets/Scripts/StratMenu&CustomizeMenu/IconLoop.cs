using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconLoop : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y == 9)
        {
            transform.position = new Vector3(transform.position.x, -9, 0);
        }

        if (transform.position.y == -12)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
    }
}
