using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClownMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform tf;
    [SerializeField] SpriteRenderer SR;
    public Sprite deathSprite;
    float rotation;
    [SerializeField] int moveSpeed = 1000;
    [SerializeField] float rotateSpeed = 10000f;
    [SerializeField] int spinTimer = 1000;
    bool spinning = true;

    // Start is called before the first frame update
    void Start()
    {
        rotation = Random.Range(Mathf.PI*1.4f, Mathf.PI*1.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(spinning)
        {
            rb.velocityY = (float)moveSpeed * Mathf.Sin(rotation) * LevelController.Instance.speedMultiplier * Time.deltaTime;
            rb.angularVelocity = rotateSpeed * Time.deltaTime;
        }
        if(spinTimer <= 0)
        {
            spinning = false;
        }
        else
        {
            tf.rotation = Quaternion.Euler(0, 0, 0);
            SR.sprite = deathSprite;
            spinTimer--;
        }
        
        rb.velocityX = (float) moveSpeed * Mathf.Cos(rotation) * LevelController.Instance.speedMultiplier * Time.deltaTime;
        
        if ((tf.position.x < -2) || (tf.position.y < -6))
        {
            Debug.Log("Destroying Object");
            Destroy(gameObject);
        }
    }
}
