using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bulletCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            Destroy(col);
        }
    }
}
