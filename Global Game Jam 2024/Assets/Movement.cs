using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveForce = 10f;

    [SerializeField] Rigidbody2D rb;

    float LevelProgression = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.left * moveForce * LevelProgression);
    }
}
