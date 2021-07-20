using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletMove : MonoBehaviour
{
    private float speed = 0f;

    [SerializeField] private bool redFlg;
    private GameObject playerObj;

    private void Awake()
    {
        playerObj = (redFlg) ? GameObject.Find("Player_Red") : GameObject.Find("Player_Blue");
    }

    private void Start()
    {
        // スピード取得
        this.speed = playerObj.GetComponent<IStatusGettable>().GetShotSpeed();
    }

    void Update()
    {
        // 移動
        transform.position += transform.up.normalized * speed * Time.deltaTime;
    }
}
