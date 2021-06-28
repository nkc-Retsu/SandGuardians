using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
#pragma warning disable 649
    public class EnemySpawnDirector : MonoBehaviour
    {
        // Enemy�𐶐����鏈��

        //[Space(3000)]

        /// <summary>
        /// �o������Enemy�̎�ނ��Ǘ�����enum
        /// </summary>
        enum SpawnScore
        {
            spawnLancerScore = 500,
            spawnKnightScore = 1000,
            spawnBossScore   = 2000,
        }


        // EnemyObject�擾�p�ϐ�
        [SerializeField] private GameObject enemyPorn;
        [SerializeField] private GameObject enemyLancer;
        [SerializeField] private GameObject enemyKnight;


        // lerp�̃I�u�W�F�N�g���擾����z��
        [SerializeField] private GameObject[] lerpObj;

        // �X�|�[�����x���ϐ�
        [SerializeField] private int spawnLevel = 1;


        // ���ԕϐ�
        private float time = 0;         // ���Ԍv���p�ϐ�
        private float timeCount = 5;    // �C���^�[�o���p�ϐ�




        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // ���\�b�h�Ăяo��
            SpawnEnemy();
            LevelUP();
        }


        /// <summary>
        /// score�ɂ���ďo������Enemy�̎�ނ𑝂₷����
        /// </summary>
        private void LevelUP()
        {
            // �X�R�A�ɂ���ă��x����������

            // EnemyLancer���o���\�ɂ���
            if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnLancerScore && ScoreDirector.scorePoint < (int)SpawnScore.spawnKnightScore)
            {
                spawnLevel = 2;
                timeCount = 3f;

            }
            // EnemyKnight���o���\�ɂ���
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnKnightScore && ScoreDirector.scorePoint < (int)SpawnScore.spawnBossScore)
            {
                spawnLevel = 3;
                timeCount = 2f;

            }
            // EnemyBoss���o���\�ɂ���
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnBossScore)
            {
                spawnLevel = 4;
                timeCount = 1f;

            }
        }


        /// <summary>
        /// Enemy���o�������鏈��
        /// </summary>
        private void SpawnEnemy()
        {

            // �o���ʒu�������_���ɂ���

            // �����_���p�ϐ�
            float randNum;
            Vector2 spawnPos;
            int spaceNum;


            // �����_���̒l����
            randNum = Random.Range(0f, 3.9f);

            // lerpObj��ύX����ϐ�
            spaceNum = Random.Range(1, 100) % 4;

            // �o���ʒu�������_��
            spawnPos = Vector2.Lerp(lerpObj[spaceNum].transform.position, lerpObj[spaceNum + 1].transform.position, randNum % 1);


            // ���Ԃ��v��
            time += Time.deltaTime;

            // �C���^�[�o��
            if (time >= timeCount)
            {
                // �����_���ɂ���
                Random.Range(0, spawnLevel);

                // ���Ԃ�������
                time = 0;

                // �o�������鏈��
                switch (Random.Range(0, spawnLevel))
                {
                    case 0:
                        Debug.Log("Porn�o��");
                        Instantiate(enemyPorn).transform.position = spawnPos;
                        break;

                    case 1:
                        Debug.Log("Lancer�o��");
                        Instantiate(enemyLancer).transform.position = spawnPos;
                        break;

                    case 2:
                        Debug.Log("Knight�o��");
                        Instantiate(enemyKnight).transform.position = spawnPos;
                        break;

                    case 3:
                        Debug.Log("�{�X�o��");
                        break;
                }

            }

        }

    }

}
