using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    [CreateAssetMenu]
    public class EnemyStatus : ScriptableObject
    {
        // Enemyのステータスを管理する処理

        [SerializeField, Tooltip("体力")] 　　　public int hp;
        [SerializeField, Tooltip("攻撃力")] 　　public int attackPower;
        [SerializeField, Tooltip("移動の速さ")] public float speed;
    }

}
