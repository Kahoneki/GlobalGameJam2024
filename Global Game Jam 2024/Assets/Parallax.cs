using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To be attached to all child parallax layers
public class Parallax : MonoBehaviour
{
    private float parallaxSpeed; //Layer dependent - units per frame
    private float parallaxMultiplier;
    private float spriteLength;

    void Start() {
        
        //Layers:
        //Sky - 6
        //Background - 7
        //Road - 8
        //Foreground - 9
        parallaxSpeed = (float)(((float)gameObject.layer - 5)/4 + 0.25); //Range transformation [6,9] -> [1,4] -> [0.25,1] -> [0.5,1.25] (This transformation ensures that the road layer has a parallax speed of 1)
        parallaxMultiplier = 0.05f;
        Debug.Log((gameObject.layer - 5)/4);
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        if (transform.position.x < -(spriteLength)) //Out of bounds
            Destroy(gameObject);

        Vector3 deltaPos = new Vector3(parallaxSpeed * parallaxMultiplier, 0, 0);
        transform.position -= deltaPos;
    }
}
