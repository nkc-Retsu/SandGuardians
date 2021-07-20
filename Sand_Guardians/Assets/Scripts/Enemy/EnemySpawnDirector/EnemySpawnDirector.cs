using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
#pragma warning disable 649
    public class EnemySpawnDirector : MonoBehaviour
    {
        // Enemyを生成する処理

        //[Space(3000)]

        /// <summary>
        /// 出現するEnemyの種類を管理するenum
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


        // EnemyObject取得用変数
        [SerializeField] private GameObject enemyPorn;
        [SerializeField] private GameObject enemyLancer;
        [SerializeField] private GameObject enemyKnight;

        // ScriptableOject取得用変数
        [SerializeField] private EnemyStatus enemyStatus_Porn;
        [SerializeField] private EnemyStatus enemyStatus_Lanacer;
        [SerializeField] private EnemyStatus enemyStatus_Knight;


        // Sprite
        private SpriteRenderer sr_Porn;   
        private SpriteRenderer sr_Lanacer;   
        private SpriteRenderer sr_Knight;   

        // lerpのオブジェクトを取得する配列
        [SerializeField] private GameObject[] lerpObj;



        // PornのLevel別のステータス
        [SerializeField] private int[]   attackTable_Porn   = { };  
        [SerializeField] private int[]   hpTable_Porn       = { };
        [SerializeField] private float[] speedTable_Porn    = { };
        [SerializeField] private int[]   pointTable_Porn    = { };

        // LancerのLevel別のステータス
        [SerializeField] private int[]   attackTable_Lancer = { };
        [SerializeField] private int[]   hpTable_Lancer     = { };
        [SerializeField] private float[] speedTable_Lancer  = { };
        [SerializeField] private int[]   pointTable_Lancer  = { };

        // KnightのLevel別のステータス
        [SerializeField] private int[]   attackTable_Knight = { };
        [SerializeField] private int[]   hpTable_Knight     = { };
        [SerializeField] private float[] speedTable_Knight  = { };
        [SerializeField] private int[]   pointTable_Knight  = { };


        // レベル管理配列
        private int[] levelTable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int level;

        // スポーンレベル変数
        private int spawnLevel = 1;


        // 時間変数
        private float time = 0;         // 時間計測用変数
        private float timeCount = 5;    // インターバル用変数




        // Start is called before the first frame update
        void Start()
        {

            sr_Porn    = GetComponent<SpriteRenderer>();
            sr_Lanacer = GetComponent<SpriteRenderer>();
            sr_Knight  = GetComponent<SpriteRenderer>();


            // レベル変数を0にする
            int level = levelTable[0];

            EnemyStateChange_Porn  (attackTable_Porn[level],     hpTable_Porn[level],   speedTable_Porn[level],   pointTable_Porn[level]);
            EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
            EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

        }

        // Update is called once per frame
        void Update()
        {
            // メソッド呼び出し
            SpawnEnemy();
            LevelUP();
        }



        /// <summary>
        /// scoreによって出現するEnemyの種類を増やす処理
        /// </summary>
        private void LevelUP()
        {
            // スコアによってレベルが増える

            // EnemyLancerを出現可能にする
            if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnLancerScore && ScoreDirector.scorePoint < (int)SpawnScore.spawnKnightScore)
            {
                spawnLevel = 2;
                timeCount = 3f;

            }
            // EnemyKnightを出現可能にする
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnKnightScore && ScoreDirector.scorePoint < (int)SpawnScore.spawnBossScore)
            {
                spawnLevel = 3;
                timeCount = 2f;

            }
            // EnemyBossを出現可能にする
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnBossScore && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_1)
            {
                spawnLevel = 4;
                timeCount = 1f;
            }



            // LevelUP
            // Hard_Level_1
            if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_1 && ScoreDirector.scorePoint <=(int)SpawnScore.HardScore_Level_2)
            {
                Debug.Log("レベル1");
                timeCount = 2f;
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_2 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_3)
            {
                 if(level < levelTable[1])
                {
                    Debug.Log("レベル2");
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
                    Debug.Log("レベル3");
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
                    Debug.Log("レベル4");
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
                    Debug.Log("レベル5");
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
                    Debug.Log("レベル6");
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
                    Debug.Log("レベル7");
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
                    Debug.Log("レベル8");
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
                    Debug.Log("レベル9");
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
                    Debug.Log("地獄の始まり");
                    level = levelTable[10];

                    EnemyStateChange_Porn(attackTable_Porn[level], hpTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(attackTable_Lancer[level], hpTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(attackTable_Knight[level], hpTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                }

            }

        }


        /// <summary>
        /// Enemyを出現させる処理
        /// </summary>
        private void SpawnEnemy()
        {

            // 出現位置をランダムにする

            // ランダム用変数
            float randNum;
            Vector2 spawnPos;
            int spaceNum;


            // ランダムの値を代入
            randNum = Random.Range(0f, 3.9f);

            // lerpObjを変更する変数
            spaceNum = Random.Range(1, 100) % 4;

            // 出現位置をランダム
            spawnPos = Vector2.Lerp(lerpObj[spaceNum].transform.position, lerpObj[spaceNum + 1].transform.position, randNum % 1);


            // 時間を計測
            time += Time.deltaTime;

            // インターバル
            if (time >= timeCount)
            {
                // ランダムにする
                Random.Range(0, spawnLevel);

                // 時間を初期化
                time = 0;

                // 出現させる処理
                switch (Random.Range(0, spawnLevel))
                {
                    // Porn出現
                    case 0:
                        Instantiate(enemyPorn).transform.position = spawnPos;
                        break;

                    // Lancer出現
                    case 1:
                        Instantiate(enemyLancer).transform.position = spawnPos;
                        break;

                    // Knight出現
                    case 2:
                        Instantiate(enemyKnight).transform.position = spawnPos;
                        break;

                    case 3:
                        Debug.Log("ボス出現");
                        break;
                }

            }

        }




        // Pornのステータスを変更
        private void EnemyStateChange_Porn(int hp, int attack, float speed,int point)
        {
            enemyStatus_Porn.attackPower = attack;
            enemyStatus_Porn.speed       = speed;
            enemyStatus_Porn.attackPower = hp;
            enemyStatus_Porn.enemyPoint = point;
        }

        // Lancerのステータスを変更
        private void EnemyStateChange_Lancer(int hp, int attack, float speed, int point)
        {
            enemyStatus_Lanacer.attackPower = attack;
            enemyStatus_Lanacer.speed = speed;
            enemyStatus_Lanacer.hp = hp;
            enemyStatus_Lanacer.enemyPoint = point;
        }

        // Knightのステータスを変更
        private void EnemyStateChange_Knight(int hp, int attack, float speed, int point)
        {
            enemyStatus_Knight.attackPower = attack;
            enemyStatus_Knight.speed = speed;
            enemyStatus_Knight.hp = hp;
            enemyStatus_Knight.enemyPoint = point;
        }
    }

}
