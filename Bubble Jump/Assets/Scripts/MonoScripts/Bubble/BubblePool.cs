using System.Collections.Generic;
using UnityEngine;

public class BubblePool : MonoBehaviour
{    
    // Public
    public static BubblePool instance;

    // Private
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int amountToPool = 10;

    [SerializeField] private GameObject bubblePrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateBubblepool();
    }

    private void CreateBubblepool()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj  = Instantiate(bubblePrefab);
            obj.transform.SetParent(transform, false);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledBubble()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }


}
