using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace Player
//{
//    public class PlayerTurn : MonoBehaviour
//    {
//        [SerializeField] public List<GameObject> turnPoints;

//        private float[] turnPointDistances;

//        private void Start()
//        {
//            Array.Resize(ref turnPointDistances, turnPoints.Count);

//            for (int i = 0; i < turnPoints.Count - 1; ++i)
//            {
//                turnPointDistances[i] = (turnPoints[i].transform.position - turnPoints[i + 1].transform.position).magnitude;
//            }

//            for (int i = 0; i < turnPoints.Count - 1; ++i)
//            {
//                Debug.Log(turnPointDistances[i]);
//            }

//        }

//        private void Update()
//        {

//        }

//        public List<GameObject> GetTurnPoints()
//        {
//            return turnPoints;
//        }
//    }
//}
