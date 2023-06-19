using System;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject laserExplosion;
    [SerializeField] private GameObject laserMissile;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(Instantiate(laserExplosion,transform.position,Quaternion.identity),1);
            Instantiate(laserMissile, transform.position, Quaternion.identity);
        }
    }
}
