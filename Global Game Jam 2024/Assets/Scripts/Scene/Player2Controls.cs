using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controls : SpawningBase
{
    [SerializeField] GameObject obstacle;

    protected override void Update()
    {
        base.Update();

        var pos = transform.position;
        pos.y = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 
                            -LevelController.Instance.roadSize,
                            LevelController.Instance.roadSize);
        transform.position = pos;

        if (Input.GetMouseButtonDown(0) && spawnTimer <= 0)
        {
            SpawnObject(obstacle, pos.y);
        }
    }
}
