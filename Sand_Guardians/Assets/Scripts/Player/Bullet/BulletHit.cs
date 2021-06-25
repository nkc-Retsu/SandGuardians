using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletHit : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    private void OnTriggerEnter2D(Collider2D col)
    {

        IP2EAttack p2EAttack = col.gameObject.GetComponent<IP2EAttack>();
        if (p2EAttack == null)
        {

        }
        else
        {
            p2EAttack.ToEnemyAttack(damage);
        }

        Destroy(gameObject);

    }
}
