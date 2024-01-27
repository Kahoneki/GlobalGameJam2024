using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject obstacle;

    //script for player movement
    public Rigidbody2D car;
    
    public float speed;
    public float maxSpeed;
    private Vector2 moveDirection;
    
    float smooth = 10.0f;
    float tiltAngle = 15.0f;

    
 



    // Start is called before the first frame update
    void Start()
    { 
        //Getting the rigidbody of the game object
        car = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
           inputs();
           FixedUpdate();   
    }

    void FixedUpdate()
    {
        Move();
        slerp();
        /*if(car.transform.position.y > maxHeight) 
        {
            car.transform.position = new Vector2(0f , maxHeight);
        }
        else if(car.transform.position.y < minHeight) 
        {
            car.transform.position = new Vector2(0f, minHeight);      
        }
        */
    }

    void inputs() 
    {
        float y = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(0f, y); 
    }

    private void Move()
    {
        car.velocity = new Vector2(0f,moveDirection.y * speed);
        car.transform.position = Vector2.ClampMagnitude(car.transform.position, LevelController.Instance.roadSize);
    }

    void slerp() 
    {
        float tiltAroundZ = Input.GetAxis("Vertical") *tiltAngle;

        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

 
        transform.rotation = Quaternion.Slerp(transform.rotation , target , Time.deltaTime *smooth);
    }
}
