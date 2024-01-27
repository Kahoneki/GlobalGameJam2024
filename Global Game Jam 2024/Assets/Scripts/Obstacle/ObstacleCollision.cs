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
        OnHit.Invoke();
    }
}
