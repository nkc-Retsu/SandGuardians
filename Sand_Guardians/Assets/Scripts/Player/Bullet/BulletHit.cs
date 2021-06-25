using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletHit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {

        IP2EAttack p2EAttack = col.gameObject.GetComponent<IP2EAttack>();
        if (p2EAttack == null)
        {

        }
        else
        {
            p2EAttack.ToEnemyAttack(10);
        }

        Destroy(gameObject);

    }
}