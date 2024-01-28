using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFactory : MonoBehaviour
{
    public static ParallaxFactory Instance { get; private set; }

    [SerializeField] private GameObject Sky;
    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject Road;
    [SerializeField] private GameObject Foreground;

    private GameObject[] layerTypes;
    [SerializeField] private Transform[] layerTransforms; //Most recent spawned layer, in editor set as rightmost

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        layerTypes = new GameObject[4] { Sky, Background, Road, Foreground };
    }

    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    [HideInInspector] public void MoveLayer(GameObject layerObject, float speed) {
        int index = layerObject.layer - 6;
        layerObject.transform.position = layerTransforms[index].position + Vector3.right * (Parallax.spriteLength - speed * Time.deltaTime * LevelController.Instance.speedMultiplier);
        layerTransforms[index] = layerObject.transform;
    }

}
