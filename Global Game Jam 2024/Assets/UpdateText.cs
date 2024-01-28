using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{

    public TextMeshProUGUI barbellText;
    public TextMeshProUGUI knifeText;
    public TextMeshProUGUI buttonText;
    public TextMeshProUGUI pinText;
    public TextMeshProUGUI banannaText;
    public float knifecounter;
    public float barbellcounter;
    public float buttoncounter;
    public float pincounter;
    public float banannacounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        knifeText.text = knifecounter.ToString();
        barbellText.text = barbellcounter.ToString();
        buttonText.text = buttoncounter.ToString();
        pinText.text = pincounter.ToString();
        banannaText.text = banannacounter.ToString();
    }

    
}
