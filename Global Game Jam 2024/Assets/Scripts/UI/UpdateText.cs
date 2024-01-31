using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    Player2Controls player;
    public TextMeshProUGUI GenericText;
    [SerializeField] private Image img;
    [SerializeField] Sprite[] sprites = new Sprite[5];
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
     
        GenericText.text = count.ToString();
        img.sprite = sprites[type];
       

    }
}
