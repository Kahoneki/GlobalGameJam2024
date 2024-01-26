using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }

    public float speedMultiplier = 1;
    public float levelCompletionPercentage = 0;
    //public Player player; // edit once player script exists

    public int livesLeft;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    private void Update()
    {
        speedMultiplier += Time.deltaTime; // change this formula for speeding up over time
        // probs do something with completion percentage
    }
}
