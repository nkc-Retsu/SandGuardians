using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private IInputer inputer; // �C���v�b�^�[

        [SerializeField] private bool redFlg;
        private BulletPool bulletPool;
        [SerializeField] private GameObject poolObj;
        
        private Vector3 offsetPos; // ���ˈʒu����
        private float offsetRate = 0.2f; // ���ˈʒu�����p

        private float timeSecondCounter = 0; // �^�C�}�[
        [SerializeField] private float attackSpan = 0.2f;�@// ���ˊԊu

        private AudioSource audioSource;
        [SerializeField] AudioClip shotSound;

        void Start()
        {
            // �R���|�[�l���g�擾
            inputer = GetComponent<IInputer>();
            attackSpan = GetComponent<IStatusGettable>().GetShotInterval();
            bulletPool = poolObj.GetComponent<BulletPool>();
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            timeSecondCounter -= Time.deltaTime; // �^�C�}�[���Z

            if (inputer.Attack()) // �U���{�^����������Ă�����
            {
                if(timeSecondCounter<=0) // ���ˊԊu���Ԃ��o�߂��Ă�����
                {
                    Attack(); // �U�������Ăяo��
                    timeSecondCounter = attackSpan; // �^�C�}�[�Đݒ�
                }
            }

        }

        void Attack()
        {
            offsetPos = transform.up * offsetRate; // ���ˈʒu����
            GameObject bullet;
            bullet = (redFlg) ? bulletPool.GetRedBullet() : bulletPool.GetBlueBullet();
            
            bullet.SetActive(true);
            bullet.transform.position = transform.position + offsetPos;
            bullet.transform.localEulerAngles = transform.localEulerAngles;
            audioSource.PlayOneShot(shotSound); // ��
        }
    }
}
