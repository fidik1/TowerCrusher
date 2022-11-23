using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    [SerializeField] private Cube _particleDeath;
    public Action<Block> BlockDestroyed;

    public void DestroyBlock(Vector3 targetPos)
    {
        BlockDestroyed?.Invoke(this);
        Vector3 vector = new (UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f));
        Cube cube = Instantiate(_particleDeath, transform.position - vector, Quaternion.identity, transform.parent);
        cube.targetPos = targetPos;
        Cube cube1 = Instantiate(_particleDeath, transform.position, Quaternion.identity, transform.parent);
        cube1.targetPos = targetPos;
        vector = new(UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f));
        Cube cube2 = Instantiate(_particleDeath, transform.position - vector, Quaternion.identity, transform.parent);
        cube2.targetPos = targetPos;
        Destroy(gameObject);
    }
}
