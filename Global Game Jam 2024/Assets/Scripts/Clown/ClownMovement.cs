using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform tf;
    float rotation;
    [SerializeField] int moveSpeed = 1000;
    // Start is called before the first frame update
    void Start()
    {
        rotation = Random.Range(Mathf.PI*1.4f, Mathf.PI*1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocityX = (float) moveSpeed * Mathf.Cos(rotation) * LevelController.Instance.speedMultiplier * Time.deltaTime;
        rb.velocityY = (float) moveSpeed * Mathf.Sin(rotation) * LevelController.Instance.speedMultiplier * Time.deltaTime;
        if ((tf.position.x < -2) || (tf.position.y < -6))
        {
            Debug.Log("Destroying Object");
            Destroy(gameObject);
        }
    }
}
