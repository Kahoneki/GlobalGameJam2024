using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To be attached to all child parallax layers
public class Parallax : MonoBehaviour
{
    private float parallaxSpeed; //Layer dependent - units per frame
    private float moveSpeed = 10f;
    [HideInInspector] public static float spriteLength;

    private float horizontalCameraHalfSize;

    void Awake() {

        //Layers:
        //Sky - 6
        //Background - 7
        //Road - 8
        //Foreground - 9
        parallaxSpeed = (((float)gameObject.layer - 5)/4)+0.25f; //Range transformation [6,9] -> [0.5,1.25] (This transformation ensures that the road layer has a parallax speed of 1)
        
        spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
        
        horizontalCameraHalfSize = Camera.main.orthographicSize * ((float)Screen.width/Screen.height);
    }

    void Update() {
        Vector3 deltaPos = new Vector3(parallaxSpeed * moveSpeed * LevelController.Instance.speedMultiplier * Time.deltaTime, 0, 0);
        transform.position -= deltaPos;
        if (transform.position.x <= 2 * -(horizontalCameraHalfSize + spriteLength/2)) { //Out of bounds
            ParallaxFactory.Instance.MoveLayer(gameObject, parallaxSpeed * moveSpeed);
        }
    }
}
