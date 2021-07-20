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
            HardScore_Level_2     =  7000,
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
        [SerializeField] private EnemyStatus enemyStatus_Porn;
        [SerializeField] private EnemyStatus enemyStatus_Lanacer;
        [SerializeField] private EnemyStatus enemyStatus_Knight;


        // Sprite
        private SpriteRenderer sr_Porn;   
        private SpriteRenderer sr_Lanacer;   
        private SpriteRenderer sr_Knight;   

        // lerp�̃I�u�W�F�N�g���擾����z��
        [SerializeField] private GameObject[] lerpObj;



        // Porn��Level�ʂ̃X�e�[�^�X
        [SerializeField] private int[]   attackTable_Porn   = { };  
        [SerializeField] private int[]   hpTable_Porn       = { };
        [SerializeField] private float[] speedTable_Porn    = { };
        [SerializeField] private int[]   pointTable_Porn    = { };

        // Lancer��Level�ʂ̃X�e�[�^�X
        [SerializeField] private int[]   attackTable_Lancer = { };
        [SerializeField] private int[]   hpTable_Lancer     = { };
        [SerializeField] private float[] speedTable_Lancer  = { };
        [SerializeField] private int[]   pointTable_Lancer  = { };

        // Knight��Level�ʂ̃X�e�[�^�X
        [SerializeField] private int[]   attackTable_Knight = { };
        [SerializeField] private int[]   hpTable_Knight     = { };
        [SerializeField] private float[] speedTable_Knight  = { };
        [SerializeField] private int[]   pointTable_Knight  = { };


        // ���x���Ǘ��z��
        private int[] levelTable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int level;

        // �X�|�[�����x���ϐ�
        private int spawnLevel = 1;


        // ���ԕϐ�
        private float time = 0;         // ���Ԍv���p�ϐ�
        private float timeCount = 5;    // �C���^�[�o���p�ϐ�




        // Start is called before the first frame update
        void Start()
        {

            sr_Porn    = GetComponent<SpriteRenderer>();
            sr_Lanacer = GetComponent<SpriteRenderer>();
            sr_Knight  = GetComponent<SpriteRenderer>();


            // ���x���ϐ���0�ɂ���
            int level = levelTable[0];

            EnemyStateChange_Porn  (attackTable_Porn[level],     hpTable_Porn[level],   speedTable_Porn[level],   pointTable_Porn[level]);
            EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
            EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

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



            // LevelUP
            // Hard_Level_1
            if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_1 && ScoreDirector.scorePoint <=(int)SpawnScore.HardScore_Level_2)
            {
                Debug.Log("���x��1");
                timeCount = 2f;
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_2 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_3)
            {
                 if(level < levelTable[1])
                {
                    Debug.Log("���x��2");
                    level = levelTable[1];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_3 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_4)
            {
                if (level < levelTable[2])
                {
                    Debug.Log("���x��3");
                    level = levelTable[2];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_4 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_5)
            {
                if (level < levelTable[3])
                {
                    Debug.Log("���x��4");
                    level = levelTable[3];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_5 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_6)
            {
                if (level < levelTable[4])
                {
                    Debug.Log("���x��5");
                    level = levelTable[4];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_6 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_7)
            {
                if (level < levelTable[5])
                {
                    Debug.Log("���x��6");
                   level = levelTable[5];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_7 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_8)
            {
                if (level < levelTable[6])
                {
                    Debug.Log("���x��7");
                    level = levelTable[6];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_8 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_9)
            {
                if (level < levelTable[7])
                {
                    Debug.Log("���x��8");
                    level = levelTable[7];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_9 && ScoreDirector.scorePoint <= (int)SpawnScore.The_beginning_of_hell)
            {
                if (level < levelTable[8])
                {
                    Debug.Log("���x��9");
                    level = levelTable[8];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.The_beginning_of_hell)
            {
                if (level < levelTable[9])
                {
                    Debug.Log("�n���̎n�܂�");
                    level = levelTable[10];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

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




        // Porn�̃X�e�[�^�X��ύX
        private void EnemyStateChange_Porn(int hp, int attack, float speed,int point)
        {
            enemyStatus_Porn.attackPower = attack;
            enemyStatus_Porn.speed       = speed;
            enemyStatus_Porn.attackPower = hp;
            enemyStatus_Porn.enemyPoint = point;
        }

        // Lancer�̃X�e�[�^�X��ύX
        private void EnemyStateChange_Lancer(int hp, int attack, float speed, int point)
        {
            enemyStatus_Lanacer.attackPower = attack;
            enemyStatus_Lanacer.speed = speed;
            enemyStatus_Lanacer.hp = hp;
            enemyStatus_Lanacer.enemyPoint = point;
        }

        // Knight�̃X�e�[�^�X��ύX
        private void EnemyStateChange_Knight(int hp, int attack, float speed, int point)
        {
            enemyStatus_Knight.attackPower = attack;
            enemyStatus_Knight.speed = speed;
            enemyStatus_Knight.hp = hp;
            enemyStatus_Knight.enemyPoint = point;
        }
    }

}
