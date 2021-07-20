using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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

        //倍率
        [SerializeField] float magnification = 1.1f;


        // EnemyObject取得用変数
        [SerializeField] private GameObject enemyPorn;
        [SerializeField] private GameObject enemyLancer;
        [SerializeField] private GameObject enemyKnight;

        // ScriptableOject取得用変数
        [SerializeField] private EnemyStatus enemyStatus_Porn;
        [SerializeField] private EnemyStatus enemyStatus_Lanacer;
        [SerializeField] private EnemyStatus enemyStatus_Knight;


        [SerializeField] private Text levelText;


        // Sprite
        private SpriteRenderer sr_Porn;
        private SpriteRenderer sr_Lanacer;   
        private SpriteRenderer sr_Knight;   


        // lerpのオブジェクトを取得する配列
        [SerializeField] private GameObject[] lerpObj;



        // PornのLevel別のステータス
        [Header("Pornの攻撃力"),SerializeField]    private int[]   attackTable_Porn   = { };
        [Header("PornのHP"), SerializeField]       private int[]   hpTable_Porn       = { };
        [Header("Pornのスピード"), SerializeField] private float[] speedTable_Porn    = { };
        [Header("Pornのポイント"), SerializeField] private int[]   pointTable_Porn    = { };

        // LancerのLevel別のステータス
        [Header("Lancerの攻撃力"), SerializeField]   private int[]   attackTable_Lancer = { };
        [Header("LancerのHP"), SerializeField]       private int[]   hpTable_Lancer     = { };
        [Header("Lancerのスピード"), SerializeField] private float[] speedTable_Lancer  = { };
        [Header("Lancerのポイント"), SerializeField] private int[]   pointTable_Lancer  = { };

        // KnightのLevel別のステータス
        [Header("Knightの攻撃力"), SerializeField] 　private int[]   attackTable_Knight = { };
        [Header("KnightのHP"), SerializeField] 　　　private int[]   hpTable_Knight     = { };
        [Header("Knightのスピード"), SerializeField] private float[] speedTable_Knight  = { };
        [Header("Knightのポイント"), SerializeField] private int[]   pointTable_Knight  = { };


        // 変更用Sprite変数
        [SerializeField] Sprite[] sr;


        // レベル管理配列
        private int[] levelTable = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private int level;



        // スポーンレベル変数
        //private int spawnLevel = 1;


        // 時間変数
        private float time = 0;         // 時間計測用変数
        private float timeCount = 5;    // インターバル用変数

        // 配列の要素数
        private int randMax;

        // テキストで表示する値
        private int textNum;


        // Start is called before the first frame update
        void Start()
        {

            // コンポーネント取得
            sr_Porn = enemyPorn.GetComponent<SpriteRenderer>();
            sr_Lanacer = enemyLancer.GetComponent<SpriteRenderer>();
            sr_Knight  = enemyKnight.GetComponent<SpriteRenderer>();


            // レベル変数を0にする
            int level = levelTable[0];


            // ステータスを初期化
            EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
            EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
            EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);


            // スプライトを変更
            sr_Porn.sprite    = sr[0];
            sr_Lanacer.sprite = sr[1];
            sr_Knight.sprite  = sr[2];

            // 配列の要素数を増やす
            randMax = 4;

            // テキスト用変数に現在のレベルを代入
            textNum = level + 1;

            // テキストを表示
            levelText.text = "LEVEL " + textNum;
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
            // スコアによってレベルが増える処理

            // EnemyLancerを出現可能にする
            if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnLancerScore && ScoreDirector.scorePoint < (int)SpawnScore.spawnKnightScore)
            {
                // ランダム最大値を変更
                randMax    = 8;

                // 出現スパンを変更
                timeCount  = 3f;

            }
            // EnemyKnightを出現可能にする
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnKnightScore && ScoreDirector.scorePoint < (int)SpawnScore.spawnBossScore)
            {
                // ランダム最大値を変更
                randMax = 10;

                // 出現スパンを変更
                timeCount = 2f;

            }
            // EnemyBossを出現可能にする(いつか追加するとき用)
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnBossScore && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_1)
            {
                // 出現スパンを変更
                timeCount = 1f;
            }



            // スコアによってLevelUPしていく処理
            if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_1 && ScoreDirector.scorePoint <=(int)SpawnScore.HardScore_Level_2)
            {
                // 出現スパンを変更
                timeCount = 1.5f;
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_2 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_3)
            {
                // 現在のレベルがTableLevelより小さい場合
                 if(level < levelTable[1])
                {
                    Debug.Log("レベル2");

                    // 現在のレベルを代入
                    level = levelTable[1];

                    // 敵が出てくるスパンを変更
                    timeCount = 1.5f;

                    // 敵のステータスを変更
                    EnemyStateChange_Porn(  hpTable_Porn[level],   attackTable_Porn[level],   speedTable_Porn[level],   pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level] ,speedTable_Knight[level], pointTable_Knight[level]);

                    // Spriteを変更
                    sr_Porn.sprite    = sr[3];
                    sr_Lanacer.sprite = sr[4];
                    sr_Knight.sprite  = sr[5];

                    // テキスト用変数に現在のレベルを代入
                    textNum = level + 1;

                    // テキストを表示
                    levelText.text = "LEVEL " + textNum;
                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_3 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_4)
            {
                // 現在のレベルがTableLevelより小さい場合
                if (level < levelTable[2])
                {
                    Debug.Log("レベル3");

                    // 現在のレベルを代入
                    level = levelTable[2];

                    // 敵が出てくるスパンを変更
                    timeCount = 1f;

                    // 敵のステータスを変更
                    EnemyStateChange_Porn(hpTable_Porn[level], attackTable_Porn[level], speedTable_Porn[level], pointTable_Porn[level]);
                    EnemyStateChange_Lancer(hpTable_Lancer[level], attackTable_Lancer[level], speedTable_Lancer[level], pointTable_Lancer[level]);
                    EnemyStateChange_Knight(hpTable_Knight[level], attackTable_Knight[level], speedTable_Knight[level], pointTable_Knight[level]);

                    // Spriteを変更
                    sr_Porn.sprite    = sr[6];
                    sr_Lanacer.sprite = sr[7];
                    sr_Knight.sprite  = sr[8];

                    // テキスト用変数に現在のレベルを代入
                    textNum = level + 1;

                    // テキストを表示
                    levelText.text = "LEVEL " + textNum;

                }
            }
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.HardScore_Level_4 && ScoreDirector.scorePoint <= (int)SpawnScore.HardScore_Level_5)
            {
                if (level < levelTable[3])
                {
                    Debug.Log("レベル4");
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
                    Debug.Log("レベル5");
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
                    Debug.Log("レベル6");
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
                    Debug.Log("レベル7");
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
        /// Enemyを出現させる処理
        /// </summary>
        private void SpawnEnemy()
        {

            // 出現位置をランダムにする

            int[] randTable = { 0,0,0,0,1,1,1,1,2,2 };

            int r = Random.Range(0, randMax);
            

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
                Random.Range(0, randNum);

                // 時間を初期化
                time = 0;


                // 出現させる処理
                switch (randTable[r])
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
            enemyStatus_Porn.hp          = hp;
            enemyStatus_Porn.enemyPoint  = point;
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


        // デバッグ用入力処理
        private void DebugInputer()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ScoreDirector.scorePoint += 500;
            }
        }
        
    }

}
