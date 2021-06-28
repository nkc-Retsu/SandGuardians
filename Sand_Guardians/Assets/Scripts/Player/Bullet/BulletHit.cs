using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletHit : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private bool isDefeat = false;

    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "Gantz") return;

        IP2EAttack p2EAttack = col.gameObject.GetComponent<IP2EAttack>();
        if (p2EAttack == null)
        {

        }
        else
        {
            p2EAttack.ToEnemyAttack(damage,ref isDefeat);
            Debug.Log(isDefeat);

            isDefeat = false;
        }

        Destroy(gameObject);

    }
}
