using UnityEngine;

public class ProceduralSpawner : MonoBehaviour
{
    // Private
    [SerializeField] private Transform startingSpawnPoint;
    [SerializeField] private float spawningYDist = 5f;
    private Transform spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = startingSpawnPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Spwaner();
    }

    private void Spwaner()
    {
        GameObject bubble = BubblePool.instance.GetPooledBubble();

        if (bubble != null)
        {
            bubble.transform.position = spawnPoint.position;
            bubble.SetActive(true);
            spawnPoint.position = new Vector2(Random.Range(-1.5f, 1.5f), spawnPoint.position.y + spawningYDist);
        }
    }
}
