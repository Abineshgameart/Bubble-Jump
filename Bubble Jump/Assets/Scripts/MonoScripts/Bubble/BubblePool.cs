using System.Collections.Generic;
using UnityEngine;

public class BubblePool : MonoBehaviour
{    
    // Public
    public static BubblePool instance;  // To set the bubblepool to instantiate only for once

    // Private
    private List<GameObject> pooledObjects = new List<GameObject>();  // pool list
    [SerializeField] private int amountToPool = 10;  // amount of obj to needed to pool

    [SerializeField] private GameObject bubblePrefab;  // Bubble prefab

    private void Awake()
    {
        // if the instance is not null then instance this script
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateBubblepool(); // calling method to create pool of bubbles
    }

    // Methond to create bubble
    private void CreateBubblepool()
    {
        // create the pool of bubble with for loop
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj  = Instantiate(bubblePrefab); // getting it instantiated
            obj.transform.SetParent(transform, false); // assigning under the bubble pool parent object
            obj.SetActive(false);  // Setting the active false
            pooledObjects.Add(obj); // Adding to the pool list
        }
    }

    // Method to get the bubble from the pool created
    public GameObject GetPooledBubble()
    {
        // To check that the bubble is inactive or not from the pool list
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            // Cehcking for inactive bubble to return
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i]; // returing inactive bubble from the poll list
            }
        }

        return null; // or else seding null
    }


}
