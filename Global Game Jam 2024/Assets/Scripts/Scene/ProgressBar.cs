using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class ProgressBar : MonoBehaviour
{

    LevelController levelController;
    private Slider progressSlider;

    public float FillSpeed = 120f;
    private float targetProgress = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        progressSlider = GetComponent<Slider>();
    }

    void Start()
    {
        IncrementProgress(1f);
    }

    // Update is called once per frame
    void Update()
    {
       if(progressSlider.value < targetProgress)
        {
            progressSlider.value += FillSpeed * Time.deltaTime;
        } 
    }


    public void IncrementProgress(float newProgress)
    {
       targetProgress = progressSlider.value + newProgress;   
    }
}
