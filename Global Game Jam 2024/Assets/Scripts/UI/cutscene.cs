using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour
{


    



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(passiveMe(5));
    }
    private void Awake()
    {
     

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator passiveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        SceneManager.LoadScene("Main Scene");
    }


}
