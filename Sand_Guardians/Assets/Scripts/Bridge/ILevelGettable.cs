using UnityEngine;

namespace Bridge
{
    interface ILevelGettable
    {
        int GetPowerLevel();
        int GetShotSpeedLevel();
        int GetShotIntervalLevel();
        int GetSpeedLevel();
    }
}