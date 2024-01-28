using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawningBase : MonoBehaviour
{
    public UnityEvent<float, float> OnTimerChange;

    [SerializeField] float spawnSpeedModifier = 0.1f;
    [SerializeField] float spawnPosition = 18f;
    [SerializeField] float initialSpawnDelay = 1000;
    [SerializeField] float spawnDelayLimit = 1;
    protected float spawnTimer;
    float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        spawnDelay = initialSpawnDelay;
        spawnTimer = spawnDelay;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        spawnDelay = initialSpawnDelay - ((LevelController.Instance.speedMultiplier * spawnSpeedModifier));
        if (spawnDelay < spawnDelayLimit) { spawnDelay = spawnDelayLimit; }
        spawnTimer -= Time.deltaTime;
        OnTimerChange.Invoke(spawnTimer, spawnDelay);
    }

    protected void SpawnObject(GameObject objectToSpawn, float spawnY)
    {
        GameObject newObject = Instantiate(objectToSpawn);
        newObject.transform.position = new (spawnPosition, spawnY);
        spawnTimer = spawnDelay;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new(spawnPosition, LevelController.Instance.roadSize), new(spawnPosition, -LevelController.Instance.roadSize));
    }
}
