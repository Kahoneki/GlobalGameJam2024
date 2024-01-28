using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player2Controls : SpawningBase
{
    public UnityEvent<int, int> OnVisualsUpdate;
    public GameObject[] selection;
    [SerializeField] GameObject obstacle;
    [SerializeField] int[] inventory = new int[5] { 999, 1, 25, 20, 15 };

    int counter = 0;

    //object counts , skittles = infinite
    //                bannas = 1
    //                mines = 25
    //                dumbells = 20
    //                knifes = 15
    //pass the selector into the array to slect the game object to spawn
    //make second array to keep iventory. pass in same counter as the selector so we know what value to effect
    //change value accordingly. when we run out, erase the respective element.

    private void Start()
    {
        NextObstacle();
    }

    protected override void Update()
    {
        base.Update();

        var pos = transform.position;
        pos.y = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                            -LevelController.Instance.roadSize,
                            LevelController.Instance.roadSize);
        transform.position = pos;

        if (Input.GetMouseButtonDown(0) && spawnTimer <= 0 && obstacle != null)
        {
            SpawnObject(obstacle, pos.y);
            inventory[counter]--;
            //subtract value from the count of the spawned object
        }
        
        if (Input.GetMouseButtonDown(1) || inventory[counter] == 0)
        {
            NextObstacle();
        }

        //selecting an object to spawn
        //need way of tracking the currently selected object
        //pass objects into array and index accordingly
        //use mouse butten right click to change the by 1 to select object
    }

    void NextObstacle()
    {
        for (int i = 0; i < selection.Length; i++)
        {
            counter++;
            if (counter == selection.Length) { counter = 0; }

            // passing in the same index variable to select the affecting value, which then will be decreased everytime the relative object is spawned
            if (inventory[counter] > 0) // if the returned value from the inventory is 0 then we move to the next object
            {
                obstacle = selection[counter]; // in all other cases the obstacle will be set to the spawn function
                OnVisualsUpdate.Invoke(counter, inventory[counter]);
                return;
            }
        }

        obstacle = null;
        OnVisualsUpdate.Invoke(counter, inventory[counter]);
    }
}
