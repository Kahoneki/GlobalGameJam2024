using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] snotController snozz;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (LevelController.Instance.ethereal) return;

        if (col.CompareTag("Obstacle"))
        {
            switch (col.name)
            {
                case "Banana(Clone)":
                    LevelController.Instance.Obliterate();
                    break;
                case "Dumbells(Clone)":
                    LevelController.Instance.Dumbelled();
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
                case "Spillage(Clone)":
                    LevelController.Instance.Spin();
                    LevelController.Instance.player.GetComponent<PlayerMovement>().splatHit();
                    break;
                case "Pin(Clone)":
                    LevelController.Instance.player.GetComponent<PlayerMovement>().pinHit();
                    LevelController.Instance.onHit.Invoke();
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
                case "EtherealPowerUp(Clone)":
                    LevelController.Instance.MakeEthereal();
                    break;
                case "HealthPowerUp(Clone)":
                    LevelController.Instance.onLifeGained.Invoke();
                    break;
                case "ShootPowerUp(Clone)":
                    LevelController.Instance.GiveAmmo();
                    if (snozz != null) { snozz.adjustSnot(); }
                    break;
                default:
                    LevelController.Instance.SlowTime();
                    break;
            }
            Destroy(col.gameObject);
        }
    }
}
