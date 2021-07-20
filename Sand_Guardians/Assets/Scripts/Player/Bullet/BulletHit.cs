using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletHit : MonoBehaviour
{
    private GameObject playerObj;
    [SerializeField] private bool redFlg;

    private int damage = 10;

    private bool isDefeat = false;

    [SerializeField] private bool canGetPoint = false;

    private GameObject spManager;
    private SpecialPointManager spManager_cs;

    private void Awake()
    {
        playerObj = (redFlg) ? GameObject.Find("Player_Red") : GameObject.Find("Player_Blue");
    }

    private void Start()
    {
        damage = playerObj.GetComponent<IStatusGettable>().GetDamage();

        spManager = GameObject.Find("SPManager");
        spManager_cs = spManager.GetComponent<SpecialPointManager>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.name == "Gantz" || col.gameObject.tag=="Bullet") return;

        IP2EAttack p2EAttack = col.gameObject.GetComponent<IP2EAttack>();
        if (p2EAttack == null)
        {

        }
        else
        {
            p2EAttack.ToEnemyAttack(damage,ref isDefeat);
            if (isDefeat && canGetPoint)
            {
                spManager_cs.AddPoint();
            }

            isDefeat = false;
        }

        gameObject.SetActive(false);
    }
}
