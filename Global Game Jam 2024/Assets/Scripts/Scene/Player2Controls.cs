using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Player2Controls : SpawningBase
{
    [SerializeField] GameObject obstacle;
    [SerializeField] public GameObject[] selection;
    [SerializeField] int[] inventory = new int[5] { 999, 1, 25, 20, 15 };

    int counter = 0;
    int current = -1;
    //object counts , skittles = infinite
    //                bannas = 1
    //                mines = 25
    //                dumbells = 20
    //                knifes = 15
    //pass the selector into the array to slect the game object to spawn
    //make second array to keep iventory. pass in same counter as the selector so we know what value to effect
    //change value accordingly. when we run out, erase the respective element.

    protected override void Update()
    {
        base.Update();

        var pos = transform.position;
        pos.y = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                            -LevelController.Instance.roadSize,
                            LevelController.Instance.roadSize);
        transform.position = pos;

        selector();

        if (Input.GetMouseButtonDown(0) && spawnTimer <= 0)
        {
            SpawnObject(obstacle, pos.y);
            
            current--;
            //subtract value from the count of the spawned object

        }
        //selecting an object to spawn
        //need way of tracking the currently selected object
        //pass objects into array and index accordingly
        //use mouse butten right click to change the by 1 to select object
    }
    void selector()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (counter == selection.Length-1)
            {
                counter = 0;
                obstacle = selection[counter];
                Debug.Log("Counter 0");
            }
            else
            {
                counter++;
                Debug.Log(counter);
            }
        }

        current = inventory[counter]; // passing in the same index variable to select the affecting value, which then will be decreased everytime the relative object is spawned
        if (inventory[counter] == 0)
        {
            counter++;
            obstacle = selection[counter];// if the returned value from the inventory is 0 then we move to the next object
            Debug.Log("works");
        }
        else
        {
            obstacle = selection[counter]; // in all other cases the obstacle will be set to the spawn function
        }




    }
}
