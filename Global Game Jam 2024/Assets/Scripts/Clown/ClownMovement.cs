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
        rb.angularVelocity = rotateSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(spinning)
        {
            rb.velocityY = (float)moveSpeed * Mathf.Sin(rotation) * LevelController.Instance.speedMultiplier;
            rb.velocityX = (float)moveSpeed * Mathf.Cos(rotation) * LevelController.Instance.speedMultiplier;
        }
        else
        {
            rb.velocityX = -10f * LevelController.Instance.speedMultiplier;
        }
        if((spinTimer <= 0) || tf.position.y < -4)
        {
            rb.velocityY = 0;
            rb.angularVelocity = 0;
            spinning = false;
            tf.rotation = Quaternion.Euler(0, 0, 0);
            SR.sprite = deathSprite;
        }
        else
        {
            spinTimer--;
        }   
        
        
        
        if (tf.position.x < -8)
        {
            Debug.Log("Destroying Object");
            Destroy(gameObject);
        }
    }
}
