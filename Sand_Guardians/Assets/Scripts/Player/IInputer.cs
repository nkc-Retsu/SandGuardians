using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    // 入力関連のインターフェイス
    interface IInputer
    {
        float Move();

        bool Attack();

        bool SpecialAttack_Red();

        bool SpecialAttack_Blue();
    }
}