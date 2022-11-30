using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    [SerializeField] private CubeParticle _particleDeath;
    public Action<Block> BlockDestroyed;

    public void DestroyBlock(Vector3 targetPos)
    {
        BlockDestroyed?.Invoke(this);
        Vector3 vector = new (UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f));
        CubeParticle cube = Instantiate(_particleDeath, transform.position - vector, Quaternion.identity, transform.parent);
        cube.SetTargetPos(targetPos);
        CubeParticle cube1 = Instantiate(_particleDeath, transform.position, Quaternion.identity, transform.parent);
        cube1.SetTargetPos(targetPos);
        vector = new(UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f));
        CubeParticle cube2 = Instantiate(_particleDeath, transform.position - vector, Quaternion.identity, transform.parent);
        cube2.SetTargetPos(targetPos);
        Destroy(gameObject);
    }
}
