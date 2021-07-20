using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
            spawnLancerScore      =    500,
            spawnKnightScore      =   1000,
            spawnBossScore        =   2000,
            HardScore_Level_1     =   3000,
            HardScore_Level_2     =   7000,
            HardScore_Level_3     =  12000,
            HardScore_Level_4     =  20000,
            HardScore_Level_5     =  30000,
            HardScore_Level_6     =  42000,
            HardScore_Level_7     =  60000,
            HardScore_Level_8     =  85000,
            HardScore_Level_9     = 110000,
            The_beginning_of_hell = 150000
        }

        //�{��
        [SerializeField] float magnification = 1.1f;


        // EnemyObject�擾�p�ϐ�
        [SerializeField] private GameObject enemyPorn;
        [SerializeField] private GameObject enemyLancer;
        [SerializeField] private GameObject enemyKnight;

        // ScriptableOject�擾�p�ϐ�
        [SerializeField] private EnemyStatus enemyStatus_Porn;
        [SerializeField] private EnemyStatus enemyStatus_Lanacer;
        [SerializeField] private EnemyStatus enemyStatus_Knight;


        [SerializeField] private Text levelText;


        // Sprite
        private SpriteRenderer sr_Porn;
        private SpriteRenderer sr_Lanacer;   
        private SpriteRenderer sr_Knight;   


        // lerp�̃I�u�W�F�N�g���擾����z��
        [SerializeField] private GameObject[] lerpObj;



        // Porn��Level�ʂ̃X�e�[�^�X
        [Header("Porn�̍U����"),SerializeField]    private int[]   attackTable_Porn   = { };
        [Header("Porn��HP"), SerializeField]       private int[]   hpTable_Porn       = { };
        [Header("Porn�̃X�s�[�h"), SerializeField] private float[] speedTable_Porn    = { };
        [Header("Porn�̃|�C���g"), SerializeField] private int[]   pointTable_Porn    = { };

        // Lancer��Level�ʂ̃X�e�[�^�X
        [Header("Lancer�̍U����"), SerializeField]   private int[]   attackTable_Lancer = { };
        [Header("Lancer��HP"), SerializeField]       private int[]   hpTable_Lancer     = { };
        [Header("Lancer�̃X�s�[�h"), SerializeField] private float[] speedTable_Lancer  = { };
        [Header("Lancer�̃|�C���g"), SerializeField] private int[]   pointTable_Lancer  = { };

        // Knight��Level�ʂ̃X�e�[�^�X
        [Header("Knight�̍U����"), SerializeField] �@private int[]   attackTable_Knight = { };
        [Header("Knight��HP"), SerializeField] �@�@�@private int[]   hpTable_Knight     = { };
        [Header("Knight�̃X�s�[�h"), SerializeField] private float[] speedTable_Knight  = { };
        [Header("Knight�̃|�C���g"), SerializeField] private int[]   pointTable_Knight  = { };


        // �ύX�pSprite�ϐ�
        [SerializeField] Sprite[] sr;


        // ���x���Ǘ��z��
        private int[] levelTable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int level;



        // �X�|�[�����x���ϐ�
        //private int spawnLevel = 1;


        // ���ԕϐ�
        private float time = 0;         // ���Ԍv���p�ϐ�
        private float timeCount = 5;    // �C���^�[�o���p�ϐ�

        // �z��̗v�f��
        private int randMax;

        // �e�L�X�g�ŕ\������l
        private int textNum;


        // Start is called before the first frame update
        void Start()
        {

            // �R���|�[�l���g�擾
            sr_Porn = enemyPorn.GetComponent<SpriteRenderer>();
            sr_Lanacer = enemyLancer.GetComponent<SpriteRenderer>();
            sr_Knight  = enemyKnight.GetComponent<SpriteRenderer>();


            // ���x���ϐ���0�ɂ���
            int level = levelTable[0];


            // �X�e�[�^�X��������
            EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
            EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
            EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);


            // �X�v���C�g��ύX
            sr_Porn.sprite    = sr[0];
            sr_Lanacer.sprite = sr[1];
            sr_Knight.sprite  = sr[2];

            // �z��̗v�f���𑝂₷
            randMax = 4;

            // �e�L�X�g�p�ϐ��Ɍ��݂̃��x������
            textNum = level + 1;

            // �e�L�X�g��\��
            levelText.text = "LEVEL " + textNum;
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
            // �X�R�A�ɂ���ă��x���������鏈��

            // EnemyLancer���o���\�ɂ���
            if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnLancerScore && ScoreDirector.scorePoint < (int)SpawnScore.spawnKnightScore)
            {
                // �����_���ő�l��ύX
                randMax    = 8;

                // �o���X�p����ύX
                timeCount  = 3f;

            }
            // EnemyKnight���o���\�ɂ���
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnKnightScore && ScoreDirector.scorePoint < (int)SpawnScore.spawnBossScore)
            {
                // �����_���ő�l��ύX
                randMax = 10;

                // �o���X�p����ύX
                timeCount = 2f;

            }
            // EnemyBoss���o���\�ɂ���(�����ǉ�����Ƃ��p)
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnBossScore && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_1)
            {
                // �o���X�p����ύX
                timeCount = 1f;
            }



            // �X�R�A�ɂ����LevelUP���Ă�������
            if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_1 && ScoreDirector.scorePoint <=(int)SpawnScore.HardScore_Level_2)
            {
                // �o���X�p����ύX
                timeCount = 1.5f;
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_2 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_3)
            {
                // ���݂̃��x����TableLevel��菬�����ꍇ
                 if(level < levelTable[1])
                {
                    Debug.Log("���x��2");

                    // ���݂̃��x������
                    level = levelTable[1];

                    // �G���o�Ă���X�p����ύX
                    timeCount = 1.5f;

                    // �G�̃X�e�[�^�X��ύX
                    EnemyStateChange_Porn(  hpTable_Porn[level],   attackTable_Porn[level],   speedTable_Porn[level],   pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level] ,speedTable_Knight[level], pointTable_Knight[level]);

                    // Sprite��ύX
                    sr_Porn.sprite    = sr[3];
                    sr_Lanacer.sprite = sr[4];
                    sr_Knight.sprite  = sr[5];

                    // �e�L�X�g�p�ϐ��Ɍ��݂̃��x������
                    textNum = level + 1;

                    // �e�L�X�g��\��
                    levelText.text = "LEVEL " + textNum;
                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_3 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_4)
            {
                // ���݂̃��x����TableLevel��菬�����ꍇ
                if (level < levelTable[2])
                {
                    Debug.Log("���x��3");

                    // ���݂̃��x������
                    level = levelTable[2];

                    // �G���o�Ă���X�p����ύX
                    timeCount = 1f;

                    // �G�̃X�e�[�^�X��ύX
                    EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                    // Sprite��ύX
                    sr_Porn.sprite    = sr[6];
                    sr_Lanacer.sprite = sr[7];
                    sr_Knight.sprite  = sr[8];

                    // �e�L�X�g�p�ϐ��Ɍ��݂̃��x������
                    textNum = level + 1;

                    // �e�L�X�g��\��
                    levelText.text = "LEVEL " + textNum;

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_4 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_5)
            {
                if (level < levelTable[3])
                {
                    Debug.Log("���x��4");
                    level = levelTable[3];

                    EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);


                    sr_Porn.sprite    =  sr[9];
                    sr_Lanacer.sprite = sr[10];
                    sr_Knight.sprite  = sr[11];

                    textNum = level + 1;
                    levelText.text = "LEVEL " + textNum;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_5 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_6)
            {
                if (level < levelTable[4])
                {
                    Debug.Log("���x��5");
                    level = levelTable[4];

                    EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);


                    sr_Porn.sprite    = sr[12];
                    sr_Lanacer.sprite = sr[13];
                    sr_Knight.sprite  = sr[14];

                    textNum = level + 1;
                    levelText.text = "LEVEL " + textNum;
                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_6 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_7)
            {
                if (level < levelTable[5])
                {
                    Debug.Log("���x��6");
                   level = levelTable[5];

                    EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);


                    sr_Porn.sprite    = sr[15];
                    sr_Lanacer.sprite = sr[16];
                    sr_Knight.sprite  = sr[17];

                    textNum = level + 1;
                    levelText.text = "LEVEL " + textNum;
                }

            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_7 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_8)
            {
                if (level < levelTable[6])
                {
                    Debug.Log("���x��7");
                    level = levelTable[6];


                    EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                    sr_Porn.sprite    = sr[18];
                    sr_Lanacer.sprite = sr[19];
                    sr_Knight.sprite  = sr[20];

                    textNum = level + 1;
                    levelText.text = "LEVEL " + textNum;

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_8 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_9)
            {
                if (level < levelTable[7])
                {
                    Debug.Log("The_beginning_of_hell");
                    level = levelTable[7];
                    timeCount = 0.5f;

                    EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);


                    sr_Porn.sprite    = sr[21];
                    sr_Lanacer.sprite = sr[22];
                    sr_Knight.sprite  = sr[23];

                    textNum = level + 1;
                    levelText.text = "LEVEL " + textNum;
                }
            }
        }


        /// <summary>
        /// Enemy���o�������鏈��
        /// </summary>
        private void SpawnEnemy()
        {

            // �o���ʒu�������_���ɂ���

            int[] randTable = { 0,0,0,0,1,1,1,1,2,2 };

            int r = Random.Range(0, randMax);
            

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
                Random.Range(0, randNum);

                // ���Ԃ�������
                time = 0;


                // �o�������鏈��
                switch (randTable[r])
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
            enemyStatus_Porn.hp          = hp;
            enemyStatus_Porn.enemyPoint  = point;
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


        // �f�o�b�O�p���͏���
        private void DebugInputer()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ScoreDirector.scorePoint += 500;
            }
        }
        
    }

}
