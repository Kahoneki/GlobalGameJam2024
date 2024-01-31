using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCrowd : MonoBehaviour
{
    Vector3 myMovement = new Vector3(0, 0, 0);
    public float mySpeed = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myMovement = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            myMovement += new Vector3(mySpeed, 0f, 0f);
        }

        transform.position = transform.position + myMovement * mySpeed;
    }
}
