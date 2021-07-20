using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bridge;

public class BulletHit : MonoBehaviour
{
    private GameObject playerObj;
    [SerializeField] private bool redFlg; // �v���C���[���Ԃ���

    private int damage; // �e�̈З� 

    private bool isDefeat = false; // ���̒e���G��|�������ǂ���

    [SerializeField] private bool canGetPoint = false; // �|�C���g���擾

    private GameObject spManager;
    private SpecialPointManager spManager_cs;

    private void Awake()
    {
        // �擾����v���C���[�I�u�W�F�N�g�̐؂�ւ�
        playerObj = (redFlg) ? GameObject.Find("Player_Red") : GameObject.Find("Player_Blue");
    }

    private void Start()
    {
        // �U���͂��擾
        damage = playerObj.GetComponent<IStatusGettable>().GetDamage();

        spManager = GameObject.Find("SPManager");
        spManager_cs = spManager.GetComponent<SpecialPointManager>();
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        // ���肵�Ȃ��^�O����
        if (col.gameObject.name == "Gantz" || col.gameObject.tag=="Bullet" || col.gameObject.tag=="Shield") return;

        // �_���[�W����̃C���^�[�t�F�C�X�������Ă�����_���[�W��^����
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
