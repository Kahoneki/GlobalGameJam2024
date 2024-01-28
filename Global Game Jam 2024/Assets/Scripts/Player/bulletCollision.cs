using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bulletCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Destroy(col.gameObject);
        }
    }
}
