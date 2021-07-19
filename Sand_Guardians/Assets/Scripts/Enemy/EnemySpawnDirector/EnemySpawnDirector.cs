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
            spawnLancerScore      =   500,
            spawnKnightScore      =  1000,
            spawnBossScore        =  2000,
            HardScore_Level_1     =  5000,
            HardScore_Level_2     =  8000,
            HardScore_Level_3     = 10000,
            HardScore_Level_4     = 12000,
            HardScore_Level_5     = 14000,
            HardScore_Level_6     = 16000,
            HardScore_Level_7     = 18000,
            HardScore_Level_8     = 20000,
            HardScore_Level_9     = 23000,
            The_beginning_of_hell = 25000
        }


        // EnemyObject�擾�p�ϐ�
        [SerializeField] private GameObject enemyPorn;
        [SerializeField] private GameObject enemyLancer;
        [SerializeField] private GameObject enemyKnight;

        // ScriptableOject�擾�p�ϐ�
        [SerializeField] private EnemyStatus enemyStatus;


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
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnBossScore && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_1)
            {
                spawnLevel = 4;
                timeCount = 1f;

            }
            // Hard_Level_1
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_1 && ScoreDirector.scorePoint <=(int)SpawnScore.HardScore_Level_2)
            {
                timeCount = 0.5f;
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_2 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_3)
            {
                 if(ScoreDirector.scorePoint == (int)SpawnScore.HardScore_Level_2)
                {
                    enemyStatus.attackPower += 10;
                    enemyStatus.hp          += 10;
                    enemyStatus.enemyPoint  += 10;
                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_3 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_4)
            {
                if (ScoreDirector.scorePoint == (int)SpawnScore.HardScore_Level_3)
                {
                    enemyStatus.attackPower += 10;
                    enemyStatus.hp += 10;
                    enemyStatus.enemyPoint += 10;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_4 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_5)
            {
                if (ScoreDirector.scorePoint == (int)SpawnScore.HardScore_Level_4)
                {
                    enemyStatus.attackPower += 10;
                    enemyStatus.hp += 10;
                    enemyStatus.enemyPoint += 10;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_5 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_6)
            {
                if (ScoreDirector.scorePoint == (int)SpawnScore.HardScore_Level_5)
                {
                    enemyStatus.attackPower += 10;
                    enemyStatus.hp += 10;
                    enemyStatus.enemyPoint += 10;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_6 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_7)
            {
                if (ScoreDirector.scorePoint == (int)SpawnScore.HardScore_Level_6)
                {
                    enemyStatus.attackPower += 10;
                    enemyStatus.hp += 10;
                    enemyStatus.enemyPoint += 10;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_7 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_8)
            {
                if (ScoreDirector.scorePoint == (int)SpawnScore.HardScore_Level_7)
                {
                    enemyStatus.attackPower += 10;
                    enemyStatus.hp += 10;
                    enemyStatus.enemyPoint += 10;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_8 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_9)
            {
                if (ScoreDirector.scorePoint == (int)SpawnScore.HardScore_Level_8)
                {
                    enemyStatus.attackPower += 10;
                    enemyStatus.hp += 10;
                    enemyStatus.enemyPoint += 10;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_9 && ScoreDirector.scorePoint <= (int)SpawnScore.The_beginning_of_hell)
            {
                if (ScoreDirector.scorePoint == (int)SpawnScore.HardScore_Level_9)
                {
                    enemyStatus.attackPower += 10;
                    enemyStatus.hp += 10;
                    enemyStatus.enemyPoint += 10;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.The_beginning_of_hell)
            {
                if (ScoreDirector.scorePoint == (int)SpawnScore.The_beginning_of_hell)
                {
                    enemyStatus.attackPower += 100;
                    enemyStatus.hp += 10;
                    enemyStatus.enemyPoint += 10;
                }

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
                    // Porn�o��
                    case 0:
                        Instantiate(enemyPorn).transform.position = spawnPos;
                        break;

                    // Lancer�o��
                    case 1:
                        Instantiate(enemyLancer).transform.position = spawnPos;
                        break;

                    // Knight�o��
                    case 2:
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
