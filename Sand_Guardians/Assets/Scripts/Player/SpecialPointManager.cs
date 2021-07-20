using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialPointManager : MonoBehaviour
{
    [SerializeField] int specialPoint = 0;
    private const int SPECIAL_POINT_MAX = 10;

    [SerializeField] private GameObject[] powerGaugeCell = new GameObject[10];

    void Start()
    {
        // ゲージの中身を非表示に
        for(int i=0;i<powerGaugeCell.Length;++i)
        {
            powerGaugeCell[i].SetActive(false);
        }
    }

    void Update()
    {

    }

    public void AddPoint()
    {
        // ポイント加算
        if(specialPoint<SPECIAL_POINT_MAX)
        {
            specialPoint++;
        }

        powerGaugeCell[specialPoint-1].SetActive(true);
    }

    public bool UsePoint(int point)
    {
        // ポイント使用
        if(specialPoint<point)
        {
            return false;
        }
        specialPoint -= point;

        for(int i=10;i>specialPoint;--i)
        {
            powerGaugeCell[i-1].SetActive(false);
        }

        return true;
        
    }
}
