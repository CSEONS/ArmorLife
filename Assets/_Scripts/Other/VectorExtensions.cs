using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 Sign(this Vector2 vec)
    {
        Vector2 sigmoidized;

        sigmoidized = new Vector2(SIGN(vec.x), SIGN(vec.y));

        return sigmoidized;
    }

    private static float SIGN(float a)
    {
        if (a > 0)
            return 1;
        if (a < 0)
            return -1;

        return 0;
    }
}
