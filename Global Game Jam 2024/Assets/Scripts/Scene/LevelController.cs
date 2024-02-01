using DG.Tweening;
using NUnit.Framework.Constraints;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{


    public static LevelController Instance { get; private set; }
    public UnityEvent onHit;
    public UnityEvent onLifeGained;

    [SerializeField] float baseSpeedMultiplier = 1f;
    public float speedMultiplier;
    public float levelCompletionPercentage = 0;
    [SerializeField] float levelTime = 120; // level lasts 120 seconds
    public float roadSize = 2;
    public bool Ethereal = false;
    public bool slowTime = false;
    public int EtherealTime = 200;
    public int EtherealTimer = 0;
    public int slowTimeTimer = 200;
    public int slowTimeTime = 0;
    public int noseAmmo = 0;
    [SerializeField] int stopDelayTime = 1000;
    [SerializeField] float changeRate = 0.7f;
    [SerializeField] GameObject splatObj;
    [SerializeField] public Transform player;
    [SerializeField] float slowTimeMultiplier = 0.5f;
    [SerializeField] Material baseMat, etherialMat, slimeMat;

    public int maxLives = 10;
    public static int livesLeft;

    //setup on creation
    private void Awake()
    {
        speedMultiplier = baseSpeedMultiplier;
        livesLeft = maxLives;
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
        levelCompletionPercentage += Time.deltaTime / levelTime;

        if (levelCompletionPercentage >= 1)
        {
            if (livesLeft >= 7) 
            {
                if (SceneManager.GetActiveScene().name == "Main Scene") { SceneManager.LoadScene("GoodScoreScene"); }
                else { SceneManager.LoadScene("GoodScoreSceneMP"); }
            }
            else 
            { 
                if (SceneManager.GetActiveScene().name == "Main Scene") { SceneManager.LoadScene("BadScoreScene"); }
                else { SceneManager.LoadScene("BadScoreSceneMP"); }
            }
        }

        //Changes speed over time
        baseSpeedMultiplier += changeRate * Time.deltaTime; // change this formula for speeding up over time

        // probs do something with completion percentage
        if (livesLeft <= 0)
        {
            if(SceneManager.GetActiveScene().name == "Main Scene") { SceneManager.LoadScene("DeathScene"); }
            else { SceneManager.LoadScene("DeathScene"); }
        }
        //Debugs Avaliable Lives
        //Debug.Log("Lives left: " + livesLeft);

        //Timer to reset invincibility
        if (EtherealTimer > 0) { EtherealTimer--; }
        else if ((EtherealTimer <= 0) && (Ethereal)) 
        { 
            Ethereal = false;
            GetComponent<SpriteRenderer>().material = baseMat;
        }
        //Timer to reset slowTime
        if (slowTimeTimer > 0) { slowTimeTimer--; }
        else if ((slowTimeTimer <= 0) && (slowTime)) 
        {
            speedMultiplier += (float )Mathf.Lerp(speedMultiplier, baseSpeedMultiplier, 0.1f);
            if(speedMultiplier >= baseSpeedMultiplier*0.9)
            {
                speedMultiplier = baseSpeedMultiplier;
                slowTime = false;
                GetComponent<SpriteRenderer>().material = baseMat;
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
        GetComponent<SpriteRenderer>().material = etherialMat;
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
        GetComponent<SpriteRenderer>().material = slimeMat;
        speedMultiplier = baseSpeedMultiplier * slowTimeMultiplier;
        slowTime = true;
        slowTimeTimer = slowTimeTime;
    }

    //Function to lose two health values
    public void Knifed()
    {
        onHit.Invoke();
        onHit.Invoke();
    }

    //Hit Dumbell
    public void Dumbelled()
    {
        onHit.Invoke();
    }

    //Function to lose a health value
    public void Hit()
    {
        livesLeft -= 1;
    }

    //Sets lives to zero on banana hit
    public void Obliterate()
    {
        for (int i = 0; i < livesLeft; i++)
        {
            onHit.Invoke();
        }
    }

    public void HitMine()
    {
        // play sound
    }

    public void Splat()
    {
        Instantiate(splatObj);
    }

    public void Spin()
    {
        player.GetComponent<PlayerMovement>().rotating = false;
        player.DORotate(Vector3.forward * 360, .5f, RotateMode.FastBeyond360)
            .OnComplete(() => { player.GetComponent<PlayerMovement>().rotating = true; });
    }
}
