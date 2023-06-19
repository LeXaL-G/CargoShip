using System;
using UnityEngine;

public class PlaneMove : MonoBehaviour
{
    public float speed = 50f, rotationSpeed = 10f,rotationSpeed2=15;
    private Quaternion targetRotation;
    private Quaternion shipRotation;
    private void Start()
    {
        targetRotation = transform.localRotation;
        shipRotation = transform.rotation;
    }

    void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward* Time.deltaTime * rotationSpeed);
            RotationLimitation();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
            RotationLimitation();
        }
        else
        {
            targetRotation.z = 0;
            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * 1f );
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-Vector3.right*Time.deltaTime*rotationSpeed);
            RotationLimitation();
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right*Time.deltaTime*rotationSpeed);
            RotationLimitation();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up*Time.deltaTime*rotationSpeed2);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down*Time.deltaTime*rotationSpeed2);
        }
    }

    private void RotationLimitation()
    {
        shipRotation.x = Mathf.MoveTowards(transform.rotation.x, 90, 1);
        shipRotation.y = Mathf.MoveTowards(transform.rotation.y, 90, 1);
        shipRotation.z = Mathf.MoveTowards(transform.rotation.z, 90, 1);
        Debug.Log("kısıtlayıcı çalıştı");
    }
}