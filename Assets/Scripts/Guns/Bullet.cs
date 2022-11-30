using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 point;
    private Vector3 _startPos;
    [SerializeField] private float _speed;

    private const string blockTag = "BlockParent";

    private void Start()
    {
        _startPos = transform.position;
        if (point == Vector3.zero)
            Destroy(gameObject);
        Destroy(gameObject, 4);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, point, _speed);
        if (transform.position == point)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(blockTag))
        {
            Balance.Instance.OnDestroyBlock();
            other.GetComponent<Block>().DestroyBlock(_startPos);
            Destroy(gameObject);
        }
    }
}
