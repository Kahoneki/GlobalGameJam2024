using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{


    public void begin()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void Quit()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }


}