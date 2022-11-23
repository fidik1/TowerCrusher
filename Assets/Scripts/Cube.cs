using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public Vector3 targetPos;
    [SerializeField] private float _force;
    private void Start()
    {
        targetPos.y += 0.1f;
        GetComponent<Rigidbody>().AddForce(targetPos * _force);
    }
}
