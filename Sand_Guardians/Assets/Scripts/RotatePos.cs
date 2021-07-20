using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePos : MonoBehaviour
{
    /// <summary>
    /// XŽ²‰ñ“]
    /// </summary>
    /// <param name="original_position"></param>
    /// <param name="angle"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    static Vector3 RotateAroundX(Vector3 original_position, float angle, float radius)
    {
        Vector3 v = original_position;
        v.z += radius;
        float a = angle * Mathf.Deg2Rad;
        float x = v.x;
        float y = Mathf.Cos(a) * v.y - Mathf.Sin(a) * v.z;
        float z = Mathf.Sin(a) * v.y - Mathf.Cos(a) * v.z;
        return new Vector3(x, y, z);
    }


    /// <summary>
    /// YŽ²‰ñ“]
    /// </summary>
    /// <param name="original_position"></param>
    /// <param name="angle"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    static Vector3 RotateAroundY(Vector3 original_position, float angle, float radius)
    {
        Vector3 v = original_position;
        v.z += radius;
        float a = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(a) * v.x + Mathf.Sin(a) * v.z;
        float y = v.y;
        float z = -Mathf.Sin(a) * v.x + Mathf.Cos(a) * v.z;
        return new Vector3(x, y, z);
    }


    /// <summary>
    /// ZŽ²‰ñ“]
    /// </summary>
    /// <param name="original_position"></param>
    /// <param name="angle"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    static Vector3 RotateAroundZ(Vector3 original_position, float angle, float radius)
    {
        Vector3 v = original_position;
        v.y += radius;
        float a = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(a) * v.x - Mathf.Sin(a) * v.y;
        float y = Mathf.Sin(a) * v.x + Mathf.Cos(a) * v.y;
        float z = v.z;
        return new Vector3(x, y, z);

    }
}
