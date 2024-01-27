using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public static Shoot Instance { get; private set; }
    public int noseAmmo = 0;
    [SerializeField] int delayTime = 500;
    [SerializeField] GameObject clownNose;
    private int shotDelay = 0;

    //setup on creation
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (shotDelay > 100) { shotDelay--; }
        else if ((shotDelay <= 0) && (noseAmmo > 0) && (Input.GetKeyUp(KeyCode.Space)))
        {
            GameObject newNose = Instantiate(clownNose);
            Vector2 Position = this.transform.position;
            newNose.transform.position = Position;
            noseAmmo--;
            shotDelay = delayTime; 
        }
    }
}
