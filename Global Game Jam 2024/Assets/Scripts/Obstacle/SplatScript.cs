using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatScript : MonoBehaviour
{
    [SerializeField] float cooldown = 3f;

    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            Destroy(gameObject);
        }
    }
}
