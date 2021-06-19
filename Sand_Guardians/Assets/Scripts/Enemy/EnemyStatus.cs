using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    [CreateAssetMenu]
    public class EnemyStatus : ScriptableObject
    {
        // Enemy�̃X�e�[�^�X���Ǘ����鏈��

        [SerializeField, Tooltip("�̗�")] �@�@�@public int hp;
        [SerializeField, Tooltip("�U����")] �@�@public int attackPower;
        [SerializeField, Tooltip("�ړ��̑���")] public float speed;
    }

}
