using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPowerUp : MonoBehaviour
{
    private void OnDestroy()
    {
        Shoot.Instance.noseAmmo = 3;
    }
}
