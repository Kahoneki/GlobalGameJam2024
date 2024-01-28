using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UpdateShootBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite emptyBar;
    public Sprite oneBar;
    public Sprite twoBar;
    public Sprite threeBar;
    public Sprite fourBar;
    public Sprite fiveBar;
    public SpriteRenderer currentImage;
    


    void Start()
    {
        currentImage = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    public void picUpda(float timeLeft, float timeTotal)
    {
        float percent = (timeTotal - timeLeft) / timeTotal;
        
        if(percent > 1.0f ) { 
        
        currentImage.sprite = fiveBar;
        
        }
        else if (percent > 0.8f)
        {
            currentImage.sprite = fourBar;
        }
        else if (percent > 0.6f)
        {
            currentImage.sprite = threeBar;
        }
        else if (percent > 0.4f)
        {
            currentImage.sprite = twoBar;
        }
        else if (percent > 0.2f)
        {
            currentImage.sprite = oneBar;
        }
        else
        {
            currentImage.sprite = emptyBar;
        }


    }
}
