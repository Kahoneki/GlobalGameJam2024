using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class textanim : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _textMeshPro;

    public string[] stringArray;

    [SerializeField] float timeBtwnChars;
    [SerializeField] float timeBtwnWords;
 


    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        EndCheck();
   //     button.SetActive(false);
    }

    void EndCheck()
    {
        if(i<= stringArray.Length - 1)
        {
            _textMeshPro.text = stringArray[i];
            StartCoroutine(TextVisible());
        }
    }

    private IEnumerator TextVisible()
    {
        _textMeshPro.ForceMeshUpdate();
        int totalVisibleCharacters = _textMeshPro.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);  
            _textMeshPro.maxVisibleCharacters = visibleCount;

            if(visibleCount >= totalVisibleCharacters)
            {

                i += 1;
                while (!Input.GetKeyDown(KeyCode.E))
                 {
                   // Invoke("EndCheck",0);
                   yield return null;
                }
                Invoke("EndCheck", 0);

                break;
                
            }
           
           

            counter += 1;
            yield return new WaitForSeconds(timeBtwnChars);
        }


      if(i == stringArray.Length)
        {
          if(  Input.GetKeyDown(KeyCode.E)) {
                SceneManager.LoadScene("Scene02");
            }
        }

    }
}
