using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector2 GetRandomVector(this Vector2 maxScatterDirection)
    {
        var v = new Vector2(
                                Random.Range((float)-maxScatterDirection.x, maxScatterDirection.x),
                                Random.Range((float)-maxScatterDirection.y, maxScatterDirection.y)
                            );

        return v;
    }
}
