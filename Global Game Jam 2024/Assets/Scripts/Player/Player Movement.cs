using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    //script for player movement
    private Rigidbody2D car;
    
    public float speed;
    private Vector2 moveDirection;
    
    float smooth = 10.0f;
    float tiltAngle = 15.0f;

    
 



    // Start is called before the first frame update
    void Start()
    { 
        //Getting the rigidbody component of the game object
        car = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //function calls for inputs and fixed update
           inputs();
           FixedUpdate();   
    }

    void FixedUpdate() // updates at a fixed interval so movement aint to buggy
    {
        Move();
        slerp();
  
    }

    void inputs() 
    {
        //only need the y axis as car cant move left or right anyway
        float y = Input.GetAxisRaw("Vertical"); // taking the absolute raw value of the input relevant to the vertical axis
        moveDirection = new Vector2(0f, y); // creating a vector that will move from the player as the direction the player will move in. in this case up or down 
    }

    private void Move()
    {
        car.velocity = new Vector2(0f,moveDirection.y * speed); // allowing the car to move along the movedirection vector at a set speed(adjustable in the inspector)
        car.transform.position = Vector2.ClampMagnitude(car.transform.position, LevelController.Instance.roadSize); // clamping the cars movement so it cant move past 2 specific points
    }

    void slerp() 
    {
        // creating a quaternion for the objects rotation, we will rotate
        // the object between 2 points with a fixed smoothing applied. these two points being the
        // objects rotation transform and a target. the target will change when the object hits a barrier to reset its rotation
        //so the object remains straight after collision

        float tiltAroundZ = Input.GetAxis("Vertical") *tiltAngle; // tilting around the z-axis 
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        if(car.transform.position.y == LevelController.Instance.roadSize || car.transform.position.y == -LevelController.Instance.roadSize) {
        
            Quaternion target2 = Quaternion.identity;
            transform.rotation = Quaternion.Slerp(target2, transform.rotation, Time.deltaTime * smooth); // applying the transform between the object and target
        }
        else  {
          transform.rotation = Quaternion.Slerp(transform.rotation , target , Time.deltaTime *smooth); //applying the rotation between the transform and target
        }
        


    }


}
