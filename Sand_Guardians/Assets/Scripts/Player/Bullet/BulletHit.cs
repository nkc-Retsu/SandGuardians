using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletHit : MonoBehaviour
{
    private GameObject playerObj;
    [SerializeField] private bool redFlg; // プレイヤーが赤か青か

    private int damage; // 弾の威力 

    private bool isDefeat = false; // この弾が敵を倒したかどうか

    [SerializeField] private bool canGetPoint = false; // ポイントを取得

    private GameObject spManager;
    private SpecialPointManager spManager_cs;

    private void Awake()
    {
        // 取得するプレイヤーオブジェクトの切り替え
        playerObj = (redFlg) ? GameObject.Find("Player_Red") : GameObject.Find("Player_Blue");
    }

    private void Start()
    {
        // 攻撃力を取得
        damage = playerObj.GetComponent<IStatusGettable>().GetDamage();

        spManager = GameObject.Find("SPManager");
        spManager_cs = spManager.GetComponent<SpecialPointManager>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        // 判定しないタグたち
        if (col.gameObject.name == "Gantz" || col.gameObject.tag=="Bullet" || col.gameObject.tag=="Shield") return;

        // ダメージ判定のインターフェイスを持っていたらダメージを与える
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
