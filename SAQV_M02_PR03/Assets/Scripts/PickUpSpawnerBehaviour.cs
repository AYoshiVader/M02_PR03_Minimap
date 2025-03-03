using UnityEngine;

public class PickUpSpawnerBehaviour : MonoBehaviour
{
    public int restockTimer = 100;
    public int spawnTimer = 0;
    public GameObject pickUp;
    public GameObject instance = null;
    public bool isSpawned = false;
    public GameBehaviour gameManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnPickUp();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSpawned && instance == null)
        {
            isSpawned = false;
            spawnTimer = restockTimer;
        }

        spawnTimer--;

        if (spawnTimer == 0)
        {
            spawnPickUp();
        }
    }

    void spawnPickUp()
    {
        GameObject newPickUp = Instantiate(pickUp, this.transform.position + this.transform.up, this.transform.rotation) as GameObject;
        instance = newPickUp;
        isSpawned = true;
    }
}
