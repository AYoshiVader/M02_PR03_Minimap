using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpBehaviour : MonoBehaviour
{
    public GameBehaviour gameManager;
    //public GameBehaviour spawner;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
        //spawner = GameObject.Find("Spawner").GetComponent<PickUpSpawnerBehaviour>();
    }
}
