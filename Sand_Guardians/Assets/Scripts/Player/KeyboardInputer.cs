using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class KeyboardInputer : MonoBehaviour ,IInputer
    {
        private void Update()
        {
            Attack();
            Move();
            SpecialAttack();
        }


        public bool Attack()
        {
            return Input.GetKeyDown(KeyCode.Z);
        }

        public float Move()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public bool SpecialAttack()
        {
            return Input.GetKeyDown(KeyCode.X);
        }
    }
}
