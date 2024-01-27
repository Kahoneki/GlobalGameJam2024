using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimePowerUp : MonoBehaviour
{
    private void OnDestroy()
    {
        LevelController.Instance.SlowTime();
    }
}
