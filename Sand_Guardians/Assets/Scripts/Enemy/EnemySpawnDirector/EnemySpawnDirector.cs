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


        // EnemyObject取得用変数
        [SerializeField] private GameObject enemyPorn;
        [SerializeField] private GameObject enemyLancer;
        [SerializeField] private GameObject enemyKnight;

        // ScriptableOject取得用変数
        [SerializeField] private EnemyStatus enemyStatus;


        // lerpのオブジェクトを取得する配列
        [SerializeField] private GameObject[] lerpObj;

        // スポーンレベル変数
        [SerializeField] private int spawnLevel = 1;


        // 時間変数
        private float time = 0;         // 時間計測用変数
        private float timeCount = 5;    // インターバル用変数




        // Start is called before the first frame update
        void Start()
        {
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

    }

}
