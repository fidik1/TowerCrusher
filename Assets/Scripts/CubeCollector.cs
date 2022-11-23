using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollector : MonoBehaviour
{
    [SerializeField] private GameObject[] _coins;
    [SerializeField] private Transform _transform;
    private const string cubeTag = "Cube";

    private int _count;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag(cubeTag))
        {
            _count++;
            Destroy(collision.gameObject);
            if (_count >= 3)
            {
                Instantiate(_coins[Random.Range(0, 3)], new Vector3(_transform.position.x - Random.Range(-0.3f, 0.3f), _transform.position.y - 0.25f, _transform.position.z), Quaternion.identity);
                _count = 0;
            }
        }
    }
}
