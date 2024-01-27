using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClown : MonoBehaviour
{
    [SerializeField] GameObject clown;
    public void spawnClown()
    {
        LevelController.Instance.livesLeft--;
        GameObject newClown = Instantiate(clown);
        Vector2 Position = this.transform.position;
        newClown.transform.position = Position;
    }
}
