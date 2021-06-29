using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletHit : MonoBehaviour
{
    [SerializeField] private int damage = 10;

    private bool isDefeat = false;

    [SerializeField] private bool canGetPoint = false;

    private GameObject spManager;
    private SpecialPointManager spManager_cs;

    private void Start()
    {
        spManager = GameObject.Find("SPManager");
        spManager_cs = spManager.GetComponent<SpecialPointManager>();
    }


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
            if (isDefeat && canGetPoint)
            {
                spManager_cs.AddPoint();
            }

            isDefeat = false;
        }

        Destroy(gameObject);

    }
}
