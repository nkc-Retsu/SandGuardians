using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float maxRotateAngle;

    GameObject targetEnemy;
    Vector3 toEnemyVec;

    void Start()
    {
        targetEnemy = GameObject.FindWithTag("Enemy");
        Debug.Log(targetEnemy);
    }

    void Update()
    {
        toEnemyVec = targetEnemy.transform.position - this.transform.position;

        transform.position += toEnemyVec.normalized * speed * Time.deltaTime;
    }

    private void SerchEnemy()
    {

    }
}
