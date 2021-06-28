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
            spawnLancerScore = 500,
            spawnKnightScore = 1000,
            spawnBossScore   = 2000,
        }


        // EnemyObject取得用変数
        [SerializeField] private GameObject enemyPorn;
        [SerializeField] private GameObject enemyLancer;
        [SerializeField] private GameObject enemyKnight;


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
            else if (ScoreDirector.scorePoint >= (int)SpawnScore.spawnBossScore)
            {
                spawnLevel = 4;
                timeCount = 1f;

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
                    case 0:
                        Debug.Log("Porn出現");
                        Instantiate(enemyPorn).transform.position = spawnPos;
                        break;

                    case 1:
                        Debug.Log("Lancer出現");
                        Instantiate(enemyLancer).transform.position = spawnPos;
                        break;

                    case 2:
                        Debug.Log("Knight出現");
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
