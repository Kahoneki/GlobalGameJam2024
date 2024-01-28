using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    Player2Controls player;
    public TextMeshProUGUI barbellText;
    public TextMeshProUGUI knifeText;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI pinText;
    public TextMeshProUGUI banannaText;
    public float knifecounter;
    public float barbellcounter;
    public float buttoncounter;
    public float banannacounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    public void invUpda(int type, int count)
    {
     
        switch (type) 
        {
            case 0:

                barbellText.text = count.ToString();
                    break;
            case 1:

                banannaText.text = count.ToString();
                break;

            case 2:

                knifeText.text = count.ToString();
                break;


            case 3:

                buttonText.text = count.ToString();
                break;

            case 4:

                pinText.text ="inf";
                break;





        }


    }
}
