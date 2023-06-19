using System;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaneCollider : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private PlaneMove _planeMove;
    [SerializeField] private FollowCamera _camera;
    [SerializeField] private List<Transform> landPoints = new List<Transform>();
    private bool isTriggedLandPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        if(isTriggedLandPoint) return;
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(Instantiate(explosion,transform.position,Quaternion.identity),1.5f);
            Destroy(gameObject);
            Destroy(Instantiate(explosion,other.transform.position,Quaternion.identity),1.5f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Base"))
        {
            _planeMove.speed = 35;
            _planeMove.rotationSpeed = 35;
            _camera.translateSpeed = 0.5f;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            _planeMove.speed = 0;
            isTriggedLandPoint = true;
            Sequence _seq = DOTween.Sequence();
            Vector3 finishPos = landPoints[Random.Range(0, landPoints.Count - 1)].position;
            finishPos.y += 3;
            _seq.Append(_planeMove.transform.DOMove(finishPos, 2f));
            gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }
    }
}