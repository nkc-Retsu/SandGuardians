using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    [CreateAssetMenu]
    public class EnemyStatus : ScriptableObject
    {
        // Enemyのステータスを管理する処理

        [SerializeField] public int hp;
        [SerializeField] public int attackPower;
        [SerializeField] public float speed;
    }

}
