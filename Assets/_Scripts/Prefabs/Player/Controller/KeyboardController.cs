using UnityEngine;

public abstract class KeyboradController: MonoBehaviour
{
    public Vector2 GetInpuAxisFloat()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(Keys.Up) || Input.GetKey(Keys.Down))
        {
            direction.y = Input.GetAxis("Vertical");
        }

        if (Input.GetKey(Keys.Right) || Input.GetKey(Keys.Left))
        {
            direction.x = Input.GetAxis("Horizontal");
        }

        return direction;
    }

    public Vector2 GetInpuAxisInt()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(Keys.Up))
        {
            direction.y = 1;
        }
        else if (Input.GetKey(Keys.Down))
        {
            direction.y = -1;
        }

        if (Input.GetKey(Keys.Right))
        {
            direction.x = 1;
        }
        else if (Input.GetKey(Keys.Left))
        {
            direction.x = -1;
        }

        return direction;
    }


}