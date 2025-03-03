using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUpBehaviour : MonoBehaviour
{
    public GameBehaviour gameManager;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            UnityEngine.Debug.Log("Shield Ready!");
            gameManager.Shields += 1;
        }
    }
}
