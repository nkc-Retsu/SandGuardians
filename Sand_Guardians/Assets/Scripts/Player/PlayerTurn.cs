using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerTurn : MonoBehaviour
    {
        private Vector3 beforeFramePos = Vector3.zero;


        private void Start()
        {
        }

        private void Update()
        {
            
        }

        private void LateUpdate()
        {
            beforeFramePos = transform.position;
        }
    }
}
