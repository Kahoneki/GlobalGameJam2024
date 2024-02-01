using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] float initialSpawnDelay = 1000;
    [SerializeField] float spawnDelayLimit = 1;
    float spawnTimer;
    float spawnDelay;
    [SerializeField] GameObject obstacle;
    [SerializeField] float SpawnSpeedModifier = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = initialSpawnDelay;
        spawnTimer = spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay = initialSpawnDelay - ((LevelController.Instance.speedMultiplier * SpawnSpeedModifier));
        if (spawnDelay < spawnDelayLimit) { spawnDelay = spawnDelayLimit; }
        //Debug.Log("Spawn Delay: " + spawnDelay);
        if (spawnTimer <= 0)
        {
            GameObject newObject = Instantiate(obstacle);
            Vector2 Position = newObject.transform.position;
            Position.x = 18f;
            Position.y = Random.Range(LevelController.Instance.roadSize, -LevelController.Instance.roadSize);
            newObject.transform.position = Position;
            spawnTimer = spawnDelay;
            //Debug.Log("I have spawned an obstacle");
        }
        spawnTimer--;
    }
}
