using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject PauseMenu, quitButton;

    private void Awake()
    {
#if UNITY_WEBGL
        Destroy(quitButton);
#endif
    }

    public void begin()
    {
        SceneManager.LoadScene("Scene01");
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
        SceneManager.LoadScene("MultiPlayer");
    }

    public void ResumeClicked()
    {
       PauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Retry()
    {
        SceneManager.LoadScene("Scene02");
    }

    public void RetryMP()
    {   
        SceneManager.LoadScene("MultiPlayer");
    }


}
