using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 Degrees;

    public void Update()
    {
        float x = Degrees.x;
        float y = Degrees.y;
        float z = Degrees.z;

        if (x != 0f)
        {
            x *= Time.deltaTime;
        }

        if (y != 0f)
        {
            y *= Time.deltaTime;
        }

        if (z != 0f)
        {
            z *= Time.deltaTime;
        }

        transform.Rotate(x, y, z);
    }
}
