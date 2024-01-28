using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] int delayTime = 500;
    [SerializeField] GameObject clownNose;
    private int shotDelay = 0;
    public int noseAmmo = 0;

    // Update is called once per frame
    void Update()
    {
        if (shotDelay > 0) { shotDelay--; }
        else if ((shotDelay <= 0) && (noseAmmo > 0) && (Input.GetKeyUp(KeyCode.Space)))
        {
            GameObject newNose = Instantiate(clownNose);
            Vector2 Position = this.transform.position;
            newNose.transform.position = Position;
            noseAmmo--;
            LevelController.Instance.noseAmmo--;
            shotDelay = delayTime; 
        }
    }
}
