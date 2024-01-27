using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    bool collisionDetected = false;
    [SerializeField] int collisionResetTime = 60;
    int collisionResetTimer = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("I have hit someting!");
        if(collisionResetTimer <= 0) 
        { 
            LevelController.Instance.livesLeft--;
            collisionResetTimer = collisionResetTime;
        }
        collisionDetected = true;
    }

    void Start()
    {
    }

    void Update()
    {
        if(collisionDetected)
        {
            if(collisionResetTimer > 0)
            {
                collisionResetTimer--;
            }
            else
            {
                collisionDetected = false;
            }
            
        }
    }
}
