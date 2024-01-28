using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningAlternative : SpawningBase
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] float[] obstacleSpawnChances;
    [SerializeField] GameObject[] powerups;
    [SerializeField] float[] powerupSpawnChances;
    [SerializeField] float powerUpToObstacleChance;

    protected override void Update()
    {
        base.Update();
        if (spawnTimer <= 0)
        {
            GameObject objToSpawn;
            float ran = Random.Range(0.0f, 100.0f);
            if (Random.Range(0, 100) < powerUpToObstacleChance) // powerup
            {
                objToSpawn = powerups[^1];
                for (int i = 0; i < powerups.Length - 1; i++)
                {
                    if (ran <= powerupSpawnChances[i])
                    {
                        objToSpawn = powerups[i];
                        break;
                    }
                    ran -= powerupSpawnChances[i];
                }
            }
            else // obstacle
            {
                if (obstacles.Length == 0) return;
                objToSpawn = obstacles[^1];
                for (int i = 0; i < obstacles.Length - 1; i++)
                {
                    if (ran <= obstacleSpawnChances[i])
                    {
                        objToSpawn = obstacles[i];
                        break;
                    }
                    ran -= obstacleSpawnChances[i];
                }
            }
            SpawnObject(objToSpawn, Random.Range(LevelController.Instance.roadSize, -LevelController.Instance.roadSize));
        }
    }
}
