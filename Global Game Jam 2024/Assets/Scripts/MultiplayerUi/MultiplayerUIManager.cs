using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MultiplayerUIManager : MonoBehaviour
{
    public Image selectedShape;
    public Sprite[] shapeSprites;

    // Start is called before the first frame update
    public void updateSelectedShape(int shapeIndex) 
    {
        if (shapeIndex >= 0 && shapeIndex < shapeSprites.Length)
        {
            selectedShape.sprite = shapeSprites[shapeIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
