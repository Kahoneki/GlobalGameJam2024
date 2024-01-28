using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPowerUp : MonoBehaviour
{
    private void OnDestroy()
    {
        LevelController.Instance.player.GetComponent<Shoot>().noseAmmo = 3;
        LevelController.Instance.noseAmmo = 3;
    }
}
