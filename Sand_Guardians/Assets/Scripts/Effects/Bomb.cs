using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void Update()
    {
        DestroyBomb();
    }

    public void DestroyBomb()
    {
        Destroy(gameObject,0.5f);
    }
}
