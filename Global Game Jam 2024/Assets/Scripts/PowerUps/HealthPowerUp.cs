using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    private void OnDestroy()
    {
        LevelController.Instance.IncrementLives();
    }
}
