using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public float SpawnTime = 1.5f;

    //public GameObject items;
    public GameObject[] items;

    private int itemIndex;
    private int tempIndex;
    private int badIndex;

    void Start()
    {
        InvokeRepeating("spawn", 0, SpawnTime);
    }

    void Update()
    {
        
    }

    void spawn()
    {
        itemIndex = Random.Range(0, SpawnPoints.Length);
        badIndex = Random.Range(0, items.Length);

        if(tempIndex == itemIndex)
        {
            Debug.Log("Same index");
            itemIndex = Random.Range(0, SpawnPoints.Length);
        }

        Instantiate(items[badIndex], SpawnPoints[itemIndex].position, SpawnPoints[itemIndex].rotation);

        tempIndex = itemIndex;
    }
}
