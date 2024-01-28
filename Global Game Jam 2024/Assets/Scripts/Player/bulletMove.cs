using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] Transform oTransform;

    [SerializeField] float moveSpeedMultiplier = 1;

    // Update is called once per frame
    void Update()
    {
        rb.velocityX = moveSpeed * LevelController.Instance.speedMultiplier * moveSpeedMultiplier;

        if (oTransform.position.x > 18)
        {
            Debug.Log("Destroying Object");
            Destroy(gameObject);
        }
    }
}
