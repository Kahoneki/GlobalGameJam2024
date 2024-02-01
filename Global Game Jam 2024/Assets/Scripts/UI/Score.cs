using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private TextMeshProUGUI livesText;


    void Update()
    { 
        if (LevelController.livesLeft >= 9)
        {
            counterText.text = "Score: A";
        }
        else  if (LevelController.livesLeft >= 7)
        {
            counterText.text = "Score: B";
        }
        else if (LevelController.livesLeft >= 5)
        {
            counterText.text = "Score: C";
        }
        else
        {
            counterText.text = "Pathetic";
        }
       livesText.text = "" + LevelController.livesLeft + " clowns made it to the party!";
    }
}
