using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class LaserHit : MonoBehaviour
{
    [SerializeField] private int laserDamage;
    private bool isDefeat;
    private void OnTriggerEnter2D(Collider2D col)
    {

        IP2EAttack p2EAttack = col.gameObject.GetComponent<IP2EAttack>();
        if (p2EAttack == null)
        {

        }
        else
        {
            p2EAttack.ToEnemyAttack(10,ref isDefeat);
        }

    }
}
