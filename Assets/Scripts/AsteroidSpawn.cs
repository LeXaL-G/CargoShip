using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroids;
    [SerializeField] private int maxCount;
    private int vertical, horizontal, spawnedCount, index;
    [SerializeField] private float asteroidSpeed ,maxSpeed,minSpeed;
    private GameObject instance;
    

    void Update()
    {
        RandomManager();
        if (spawnedCount <= maxCount)
            Spawner();
    }

    private void Spawner()
    {
        instance= Instantiate(asteroids[index], new Vector3(horizontal, vertical, 1000), Quaternion.identity);
        spawnedCount++;
        AsteroidForce(); 
    }

    private void RandomManager()
    {
        index = Random.Range(0, 3);
        vertical = Random.Range(-150, 151);
        horizontal = Random.Range(-105, 196);
        asteroidSpeed = Random.Range(minSpeed, maxSpeed);
    }

    private void AsteroidForce()
    {
        instance.GetComponent<Rigidbody>().velocity = Vector3.back*asteroidSpeed*Time.deltaTime;
    }
}