using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroyer : MonoBehaviour
{
    [SerializeField] private GameObject SpaceShip;

    private void Update()
    {
        if (SpaceShip != null)
        {
            Vector3 pos = transform.position;
            pos.z = SpaceShip.transform.position.z - 10;
            transform.position = pos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}