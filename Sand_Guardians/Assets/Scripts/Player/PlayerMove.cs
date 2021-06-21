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
        [SerializeField] private float posValue;
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

            for (int i = 0; i < turnPoints.Count - 1; ++i)
            {
                //Debug.Log(turnPointDistances[i]);
            }

        }

        void Update()
        {

            moveVec = turnPoints[posState].transform.position - turnPoints[posState + 1].transform.position;
            angle = Mathf.Atan2(moveVec.y, moveVec.x) * Mathf.Rad2Deg + 180;
            transform.localEulerAngles = new Vector3(0, 0, angle);

            // turnPoint“¯Žm‚Ì‹——£
            stateDistance = (turnPoints[posState].transform.position - turnPoints[posState + 1].transform.position).magnitude;

            // stateDistance‚ÅŠ„‚é‚±‚Æ‚ÅturnPoint‚Ì‹——£‚ª•Ï‚í‚Á‚Ä‚à‘¬“x‚ªˆê’è‚É
            posValue += inputer.Move() * speed / stateDistance * Time.deltaTime;

            // ’l‚Ì§ŒÀ
            posValue = Mathf.Clamp(posValue, 0, 3);
            posState = (int)posValue; // posValue‚Ì®”•”
            posState = Mathf.Clamp(posState, 0, 2);
            transform.position= Vector3.Lerp(turnPoints[posState].transform.position, turnPoints[posState+1].transform.position, posValue-posState);



        }
    }
}
