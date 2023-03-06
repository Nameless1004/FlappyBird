using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float _spawnInterval;
    public Vector2 StartPos;
    public GameObject[] itemPrefab;
    void Start()
    {
        InvokeRepeating("Spawn", 1.5f, _spawnInterval);
    }

    void Update()
    {
        
    }

    void Spawn()
    {
        
        Instantiate(itemPrefab[Random.Range(0,1)], StartPos, Quaternion.identity);
    }
}
