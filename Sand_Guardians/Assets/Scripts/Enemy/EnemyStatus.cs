using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    [CreateAssetMenu]
    public class EnemyStatus : ScriptableObject
    {
        // Enemy�̃X�e�[�^�X���Ǘ����鏈��

        [SerializeField] public int hp;
        [SerializeField] public int attackPower;
        [SerializeField] public float speed;
    }

}
