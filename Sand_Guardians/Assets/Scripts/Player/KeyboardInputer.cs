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
            SpecialAttack_Red();
            SpecialAttack_Blue();
        }


        public bool Attack()
        {
            return Input.GetKeyDown(KeyCode.X);
        }

        public float Move()
        {
            return Input.GetAxisRaw("Horizontal");
        }

        public bool SpecialAttack_Red()
        {
            return Input.GetKeyDown(KeyCode.Z);
        }

        public bool SpecialAttack_Blue()
        {
            return Input.GetKeyDown(KeyCode.C);
        }
    }
}
