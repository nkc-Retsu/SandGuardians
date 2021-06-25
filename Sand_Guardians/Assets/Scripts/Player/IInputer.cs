using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    interface IInputer
    {
        float Move();

        bool Attack();

        bool SpecialAttack_Red();

        bool SpecialAttack_Blue();
    }
}