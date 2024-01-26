using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    float LevelProgression = 1;
    [SerializeField] float initialSpawnDelay = 1000;
    [SerializeField] float spawnDelayLimit = 1;
    float spawnTimer;
    float spawnDelay;
    [SerializeField] GameObject obstacle;
    [SerializeField] float SpawnSpeedModifier = 0.1f;
    [SerializeField] float roadCentreY = 0f;
    [SerializeField] float halfRoadWidth = 4.5f;
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
        Debug.Log("Spawn Delay: " + spawnDelay);
        if (spawnTimer <= 0)
        {
            GameObject newObject = Instantiate(obstacle);
            Vector2 Position = newObject.transform.position;
            Position.x = 9f;
            Position.y = Random.Range(roadCentreY + halfRoadWidth, roadCentreY-halfRoadWidth);
            newObject.transform.position = Position;
            spawnTimer = spawnDelay;
            //Debug.Log("I have spawned an obstacle");
        }
        spawnTimer--;
        

    }
}
