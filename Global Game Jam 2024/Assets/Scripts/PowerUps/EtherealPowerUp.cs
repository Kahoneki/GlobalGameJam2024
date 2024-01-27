using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EtherealPowerUp : MonoBehaviour
{
    private void OnDestroy()
    {
        LevelController.Instance.MakeEthereal();
    }
}
