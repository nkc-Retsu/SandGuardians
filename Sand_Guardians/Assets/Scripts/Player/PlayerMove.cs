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
        [SerializeField] private float a;
        private int b = 0;

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
                Debug.Log(turnPointDistances[i]);
            }

        }

        void Update()
        {

            a += inputer.Move() + speed * Time.deltaTime;

            a = Mathf.Clamp(a, 0, 3);
            b = (int)a;
            b = Mathf.Clamp(b, 0, 2);
            transform.position= Vector3.Lerp(turnPoints[b].transform.position, turnPoints[b+1].transform.position, a-b);


            //switch (b)
            //{
            //    case 0:
            //        speed = turnPointDistances[b];
            //        break;
            //    case 1:
            //        break;
            //    case 2:
            //        break;
            //    default:
            //        break;
            //}

        }
    }
}
