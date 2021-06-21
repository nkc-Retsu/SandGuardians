using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        IInputer inputer;

        [SerializeField] public List<GameObject> turnPoints;

        private float[] turnPointDistances;


        [SerializeField] float speed = 5f;
        [SerializeField,Tooltip("初期位置\n(整数値がカドの位置)")] private float posValue;
        private int posState = 0;

        private float stateDistance = 0;

        Vector3 moveVec;
        float angle;

        void Start()
        {
            inputer = GetComponent<IInputer>();

            Array.Resize(ref turnPointDistances, turnPoints.Count);

            for (int i = 0; i < turnPoints.Count - 1; ++i)
            {
                turnPointDistances[i] = (turnPoints[i].transform.position - turnPoints[i + 1].transform.position).magnitude;
            }

        }

        void Update()
        {

            moveVec = turnPoints[posState].transform.position - turnPoints[posState + 1].transform.position;
            angle = Mathf.Atan2(moveVec.y, moveVec.x) * Mathf.Rad2Deg + 180;
            transform.localEulerAngles = new Vector3(0, 0, angle);

            // turnPoint同士の距離
            stateDistance = (turnPoints[posState].transform.position - turnPoints[posState + 1].transform.position).magnitude;

            // stateDistanceで割ることでturnPointの距離が変わっても速度が一定に
            posValue += inputer.Move() * speed / stateDistance * Time.deltaTime;

            // 値の制限
            posValue = Mathf.Clamp(posValue, 0, 3);
            posState = (int)posValue; // posValueの整数部
            posState = Mathf.Clamp(posState, 0, 2);
            transform.position= Vector3.Lerp(turnPoints[posState].transform.position, turnPoints[posState+1].transform.position, posValue-posState);



        }
    }
}
