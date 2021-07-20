using UnityEngine;

namespace Bridge
{
    interface IStatusGettable
    {
        int GetDamage();

        float GetSpeed();

        float GetShotInterval();

        float GetShotSpeed();
    }
}