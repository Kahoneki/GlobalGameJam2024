using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;

    [SerializeField] float rotateSpeed = 0f;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] Transform oTransform;

    [SerializeField] float moveSpeedMultiplier = 1;

    // Update is called once per frame
    void Update()
    {
        rb.velocityX = -moveSpeed * LevelController.Instance.speedMultiplier * moveSpeedMultiplier;

        rb.angularVelocity = rotateSpeed;

        if (oTransform.position.x < -3)
        {
            Debug.Log("Destroying Object");
            Destroy(gameObject);
        }
    }
}
