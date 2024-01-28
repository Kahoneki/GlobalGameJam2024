using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinObstacle : MonoBehaviour
{
    //Make car more sensitive to control
    private void OnDestroy()
    {
        PlayerMovement.Instance.pinHit();
    }
}
