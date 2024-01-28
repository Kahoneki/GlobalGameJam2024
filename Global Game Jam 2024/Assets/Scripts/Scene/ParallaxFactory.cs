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


    void Start() {
        //Automatically positioning factory to correct position
        transform.position = new Vector3(Parallax.spriteLength, 0, 0); //
    }

    [HideInInspector] public void SpawnNewLayer(int layer, float speed) {
        int index = layer - 6;
        layerTransforms[index] = Instantiate(layerTypes[index], layerTransforms[index].position + Vector3.right * (Parallax.spriteLength - speed * Time.deltaTime), transform.rotation).transform;
    }

}
