using UnityEngine;

public class LaserMissile : MonoBehaviour
{
    private Rigidbody _rb;
    private GameObject SpaceShip;
    [SerializeField] private float speed=10000f;
    [SerializeField] private GameObject explosion;
    private void Start()
    {
        SpaceShip = GameObject.Find("SpaceShip");
        transform.rotation = SpaceShip.transform.rotation;
        Destroy(this,10);
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rb.AddForce(transform.forward*speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(Instantiate(explosion,other.transform.position,Quaternion.identity),1.5f);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
