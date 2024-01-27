using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleCollision : MonoBehaviour
{
    public UnityEvent OnHit;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Obstacle"))
        {
            if (!LevelController.Instance.Ethereal) { OnHit.Invoke(); }
        }
        else if (col.CompareTag("PowerUp"))
        {
            Destroy(col);
        }
    }
}
