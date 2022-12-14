using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    [SerializeField] private CubeParticle _particleDeath;
    public Action<Block> BlockDestroyed;
    [SerializeField] private Color _color;
    [SerializeField] private Renderer _renderer;
    private MaterialPropertyBlock _materialPropertyBlock;

    private void Awake()
    {
        _materialPropertyBlock = new();
        _materialPropertyBlock.SetColor("_BaseColor", _color);
        _renderer.SetPropertyBlock(_materialPropertyBlock);
    }

    public void DestroyBlock(Vector3 targetPos)
    {
        BlockDestroyed?.Invoke(this);
        Vector3 vector = new (UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f));
        CubeParticle cube = Instantiate(_particleDeath, transform.position - vector, Quaternion.identity, transform.parent);
        cube.Init(targetPos, _materialPropertyBlock);
        CubeParticle cube1 = Instantiate(_particleDeath, transform.position, Quaternion.identity, transform.parent);
        cube1.Init(targetPos, _materialPropertyBlock);
        vector = new(UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(-0.3f, 0.3f));
        CubeParticle cube2 = Instantiate(_particleDeath, transform.position - vector, Quaternion.identity, transform.parent);
        cube2.Init(targetPos, _materialPropertyBlock);
        Destroy(gameObject);
    }
}
