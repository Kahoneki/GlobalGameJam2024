using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public LevelController levelController;
    [SerializeField] TextMeshProUGUI _textMeshPro;

    // Update is called once per frame
    void Update()
    {
        losehealth();
    }


    public void losehealth()
    {
       
        _textMeshPro.text = LevelController.livesLeft.ToString();

    }

}
