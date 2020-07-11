using UnityEngine;
using System;

public static class MathUtilities
{
    public static void Random(this ref Vector3 myVector, Vector3 min, Vector3 max)
    {
        float x = RandomVal();
        float y = RandomVal();
        float z = RandomVal();
        x += RandomVal() > 0.5 ? -1 : 1;
        y += RandomVal() > 0.5 ? -1 : 1;
        z += RandomVal() > 0.5 ? -1 : 1;
        myVector = new Vector3(x, y, z);
    }

    private static float RandomVal()
    {
        return UnityEngine.Random.value;
    }
}