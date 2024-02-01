using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class snotController : MonoBehaviour
{
    [SerializeField] Image snot1;
    [SerializeField] Image snot2;
    [SerializeField] Image snot3;

    private void Start()
    {
        adjustSnot();
    }
    public void adjustSnot()
    {
        snot1.enabled = (LevelController.Instance.noseAmmo >= 3);
        snot2.enabled = (LevelController.Instance.noseAmmo >= 2);
        snot3.enabled = (LevelController.Instance.noseAmmo >= 1);
    }
}
