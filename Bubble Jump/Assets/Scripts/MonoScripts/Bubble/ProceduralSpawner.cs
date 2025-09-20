using UnityEngine;

public class ProceduralSpawner : MonoBehaviour
{
    // Private
    [SerializeField] private Transform startingSpawnPoint;  // Starting point of the spawning
    [SerializeField] private float spawningYDist = 5f;  // y distance for nexgt spawning
    private Transform spawnPoint;  // spawnpoint for next spawning
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = startingSpawnPoint; // Setting the spawnpoint as startspawnpoint only for first spawn
    }

    // Update is called once per frame
    void Update()
    {
        Spwaner(); // Calling spawner
    }


    // Method for Spawning
    private void Spwaner()
    {
        GameObject bubble = BubblePool.instance.GetPooledBubble();  // getting the bubblepool Script and the getpoolbubble method

        // If the bubble is not null
        if (bubble != null)
        {
            bubble.transform.position = spawnPoint.position;  // setting bubble position as spwaning position
            bubble.SetActive(true); // Setting it active
            
            // setting next spawning position 
            spawnPoint.position = new Vector2(Random.Range(-1.5f, 1.5f), spawnPoint.position.y + spawningYDist);
        }
    }
}
