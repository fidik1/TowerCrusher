using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParticle : MonoBehaviour
{
    private Vector3 _targetPos;
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody _rb;

    private void Start()
    {
        _targetPos.y += 0.1f;
        _rb.AddForce(_targetPos * _force);
    }

    public void SetTargetPos(Vector3 targetPos) => _targetPos = targetPos;
}
