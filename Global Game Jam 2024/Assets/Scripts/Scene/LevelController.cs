using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }

    public float baseSpeedMultiplier = 1;
    public float speedMultiplier;
    public float levelCompletionPercentage = 0;
    public float roadSize = 4.5f;
    public bool Ethereal = false;
    public bool slowTime = false;
    public int EtherealTime = 200;
    public int EtherealTimer = 0;
    public int slowTimeTimer = 200;
    public int slowTimeTime = 0;
    public int noseAmmo = 0;
    private float savedIntMultiplier;
    private bool dumbellHit = false;
    private int stopDelay = 0;
    [SerializeField] int stopDelayTime = 1000;
    [SerializeField] float speedCatchupInterpolation = 0.01f;
    //public Player player; // edit once player script exists

    public int maxLives = 10;
    public int livesLeft;

    private void OnValidate()
    {
        if (Instance == null)
            Instance = this;
    }

    //setup on creation
    private void Awake()
    {
        livesLeft = maxLives;
        speedMultiplier = baseSpeedMultiplier;
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    //when end
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    //Update Loop
    private void Update()
    {
        if(!dumbellHit)
        {
            //Changes speed over time
            baseSpeedMultiplier += Time.deltaTime; // change this formula for speeding up over time
        }
        //changes game speed depending on slowTime power up.
        if (slowTime) { speedMultiplier = baseSpeedMultiplier / 2; } else { speedMultiplier = baseSpeedMultiplier; }
        // probs do something with completion percentage
        if (livesLeft <= 0)
        {
            Application.Quit();
        }
        //Debugs Avaliable Lives
        //Debug.Log("Lives left: " + livesLeft);

        //Timer to reset invincibility
        if (EtherealTimer > 0) { EtherealTimer--; }
        else if ((EtherealTimer <= 0) && (Ethereal)) { Ethereal = false; }
        //Timer to reset slowTime
        if (slowTimeTimer > 0) { slowTimeTimer--; }
        else if ((slowTimeTimer <= 0) && (slowTime)) { slowTime = false; }
        
        //checks if dumbell has been hit
        if(dumbellHit)
        {
            //checks if delay has occured before restarting
            if(stopDelay <= 0)
            {
                //increased speed exponentially till it reaches percentage of original speed.
                speedMultiplier = speedMultiplier + Mathf.Lerp(speedMultiplier, savedIntMultiplier, speedCatchupInterpolation);
                if (speedMultiplier >= baseSpeedMultiplier * 0.9f)
                {
                    //sets speed back to original
                    speedMultiplier = baseSpeedMultiplier;
                    dumbellHit = false;
                    stopDelay = 0;
                }
            }
            else
            {
                stopDelay--;
            }
            
        }

    }

    //Debug to show road
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(40, 2 * roadSize, 1));
    }

    //Function to make player invicible over a set time period when power up collected
    public void MakeEthereal()
    {
        Ethereal = true;
        EtherealTimer = EtherealTime;
    }

    //Function to increase lives when power up collected
    public void IncrementLives()
    {
        if (livesLeft < maxLives)
        {
            livesLeft++;
        }
    }

    //Function to slowTime
    public void SlowTime()
    {
        slowTime = true;
        slowTimeTimer = slowTimeTime;
    }

    //Function to lose two health values
    public void Knifed()
    {
        livesLeft -=2;
        if(livesLeft< 0) {livesLeft = 0;}
    }
    //Function to lose a health value
    public void Hit()
    {
        livesLeft -= 2;
    }
    //Sets lives to zero on banana hit
    public void Obliterate()
    {
        livesLeft = 0;
    }
    //Saves current game speed and sets original to zero. 
    public void hitDumbell()
    {
        dumbellHit = true;
        savedIntMultiplier = speedMultiplier;
        speedMultiplier = 0;
        stopDelay = stopDelayTime;
    }
}
