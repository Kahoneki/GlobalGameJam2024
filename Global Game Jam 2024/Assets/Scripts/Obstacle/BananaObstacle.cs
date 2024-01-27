using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaObstacle : MonoBehaviour
{
    //Outright Kills Player
    private void OnDestroy()
    {
        LevelController.Instance.Obliterate();
    }
}
