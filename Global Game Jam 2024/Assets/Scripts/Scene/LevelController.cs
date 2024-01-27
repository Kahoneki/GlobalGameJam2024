using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }

    public float speedMultiplier = 1;
    public float levelCompletionPercentage = 0;
    public float roadSize = 4.5f;
    //public Player player; // edit once player script exists

    public int livesLeft = 10;

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
        if(livesLeft <= 0)
        {
            Application.Quit();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(40, 2 * roadSize, 1));
    }
}
