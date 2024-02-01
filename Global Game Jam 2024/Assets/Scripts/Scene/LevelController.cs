using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Instance { get; private set; }
    public UnityEvent onHit;
    public UnityEvent onLifeGained;

    [SerializeField] AudioClip PowerupPickupSFX;
    [SerializeField] AudioClip ObstacleHitSFX;
    [SerializeField] AudioClip ShootNoseSFX;

    [SerializeField] float baseSpeedMultiplier = 1f;
    [SerializeField] float levelTime = 120; // level lasts 120 seconds
    [SerializeField] bool slowTime = false;
    [SerializeField] float etherealTime = 20;
    [SerializeField] float etherealTimer = 0;
    [SerializeField] float slowTimeTimer = 20;
    [SerializeField] float slowTimeTime = 0;
    [SerializeField] float changeRate = 0.7f;
    [SerializeField] GameObject splatObj;
    [SerializeField] public Transform player;
    [SerializeField] float slowTimeMultiplier = 0.5f;
    [SerializeField] Material baseMat, etherialMat, slimeMat;
    public int noseAmmo = 0;
    public float roadSize = 2;
    public bool ethereal = false;
    public float speedMultiplier;
    public float levelCompletionPercentage = 0;

    public int maxLives = 10;
    public static int livesLeft;

    AudioSource audio;

    //setup on creation
    private void Awake()
    {
        speedMultiplier = baseSpeedMultiplier;
        livesLeft = maxLives;
        audio = GetComponent<AudioSource>();

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
            if (SceneManager.GetActiveScene().name == "Main Scene") { SceneManager.LoadScene("DeathScene"); }
            else { SceneManager.LoadScene("DeathScene"); }
        }
        //Debugs Avaliable Lives
        Debug.Log("Lives left: " + livesLeft);

        //Timer to reset invincibility
        if (etherealTimer > 0) { etherealTimer -= Time.deltaTime; }
        else if ((etherealTimer <= 0) && (ethereal))
        {
            ethereal = false;
            player.GetComponent<SpriteRenderer>().material = baseMat;
        }
        //Timer to reset slowTime
        if (slowTimeTimer > 0) { slowTimeTimer-= Time.deltaTime; } // currently slowed
        else if ((slowTimeTimer <= 0) && (slowTime)) 
        {
            // currently slowed still, gradually speed back up
            speedMultiplier += (float )Mathf.Lerp(baseSpeedMultiplier*slowTimeMultiplier, baseSpeedMultiplier, 0.01f) * Time.deltaTime;
            if(speedMultiplier >= baseSpeedMultiplier*0.9) // pretty much back to speed
            {
                slowTime = false;
            }
        }
        else
        {
            speedMultiplier = baseSpeedMultiplier;
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
        ethereal = true;
        player.GetComponent<SpriteRenderer>().material = etherialMat;
        etherealTimer = etherealTime;
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
        player.GetComponent<SpriteRenderer>().material = slimeMat;
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
        audio.clip = ObstacleHitSFX;
        audio.Play();
        livesLeft -= 1;
    }

    //Sets lives to zero on banana hit
    public void Obliterate()
    {
        int clownsToKill = livesLeft;
        for (int i = 0; i < clownsToKill; i++)
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
        onHit.Invoke();
    }

    public void Spin()
    {
        player.GetComponent<PlayerMovement>().rotating = false;
        player.DORotate(Vector3.forward * 360, .5f, RotateMode.FastBeyond360)
            .OnComplete(() => { player.GetComponent<PlayerMovement>().rotating = true; });
        onHit.Invoke();
    }

    public void GiveAmmo()
    {
        noseAmmo = 3;
        player.GetComponent<Shoot>().noseAmmo = 3;
    }
}
