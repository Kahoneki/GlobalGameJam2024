using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;

    [SerializeField] Rigidbody2D rb;

    [SerializeField] Transform oTransform;

    [SerializeField] float moveSpeedMultiplier = 1;

    float LevelProgression = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocityX = -moveSpeed * LevelController.Instance.speedMultiplier * moveSpeedMultiplier * Time.deltaTime;

        if (oTransform.position.x < -10)
        {
            Debug.Log("Destroying Object");
            Destroy(gameObject);
        }
    }
}
