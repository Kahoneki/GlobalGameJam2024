using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningAlternative : SpawningBase
{
    [SerializeField] GameObject obstacle;

    protected override void Update()
    {
        base.Update();
        if (spawnTimer <= 0)
        {
            SpawnObject(obstacle, Random.Range(LevelController.Instance.roadSize, -LevelController.Instance.roadSize));
        }
    }
}
