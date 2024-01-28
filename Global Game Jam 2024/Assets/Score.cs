using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public LevelController clown;
   [SerializeField] private TextMeshProUGUI counterText;
    public float counter;
    public string Agrade = "A";
    public string Bgrade = "B";
    public string Cgrade = "C";
    public string Fail = "Fail";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (LevelController.livesLeft >= 9)
        {
            counterText.text = "A";
        }
       else  if (LevelController.livesLeft >= 7)
        {
            counterText.text = "B";
        }
       else if (LevelController.livesLeft >= 5)
        {
            counterText.text = "C";
        }
        else
        {
            counterText.text = "Pathetic";
        }
    }
}
