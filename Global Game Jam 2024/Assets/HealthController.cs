using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelController levelController;
    public Image HealthFive;
    public Image HealthFour;
    public Image HealthThree;
    public Image HealthTwo;
    public Image HealthOne;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        losehealth();
    }

    public void losehealth()
    {
        if(levelController.livesLeft == 10)
        {
            HealthFive.enabled = true;
            HealthFour.enabled = true;
            HealthThree.enabled = true;
            HealthTwo.enabled = true;
            HealthOne.enabled = true;

        }
     else   if (levelController.livesLeft == 8)
        {
            HealthFive.enabled = false;
            HealthFour.enabled = true;
            HealthThree.enabled = true;
            HealthTwo.enabled = true;
            HealthOne.enabled = true;

        }
      else  if (levelController.livesLeft == 6)
        {
            HealthFive.enabled = false;
            HealthFour.enabled = false;
            HealthThree.enabled = true;
            HealthTwo.enabled = true;
            HealthOne.enabled = true;

        }
     else   if (levelController.livesLeft == 4)
        {
            HealthFive.enabled = false;
            HealthFour.enabled = false;
            HealthThree.enabled = false;
            HealthTwo.enabled = true;
            HealthOne.enabled = true;

        }

       else if (levelController.livesLeft == 2)
        {
            HealthFive.enabled = false;
            HealthFour.enabled = false;
            HealthThree.enabled = false;
            HealthTwo.enabled = false;
            HealthOne.enabled = true;

        }
       else if (levelController.livesLeft == 0)
        {
            HealthFive.enabled = false;
            HealthFour.enabled = false;
            HealthThree.enabled = false;
            HealthTwo.enabled = false;
            HealthOne.enabled =false;

        }
    }
}
