using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleCollision : MonoBehaviour
{
    public UnityEvent OnHit;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (LevelController.Instance.Ethereal) return;

        if (col.CompareTag("Obstacle"))
        {
            switch (col.name)
            {
                case "Banana(Clone)":
                    LevelController.Instance.Obliterate();
                    break;
                case "Dumbells(Clone)":
                    LevelController.Instance.HitDumbell();
                    break;
                case "Knife(Clone)":
                    LevelController.Instance.Knifed();
                    break;
                case "Landmine(Clone)":
                    LevelController.Instance.HitMine();
                    break;
                case "BalloonAnimal(Clone)":
                    LevelController.Instance.Splat();
                    break;
                default:
                    LevelController.Instance.onHit.Invoke();
                    break;
            }
            Destroy(col.gameObject);
        }
        else if (col.CompareTag("PowerUp"))
        {
            switch (col.name)
            {
                case "EtherealPowerUp":
                    LevelController.Instance.MakeEthereal();
                    break;
                case "HealthPowerUp":
                    LevelController.Instance.onLifeGained.Invoke();
                    break;
                case "ShootPowerUp":
                    Debug.Log("Shooting not implemented");
                    break;
                default:
                    LevelController.Instance.SlowTime();
                    break;
            }
            Destroy(col.gameObject);
        }
    }
}
