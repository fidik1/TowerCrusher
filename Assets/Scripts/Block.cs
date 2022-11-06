using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Block : MonoBehaviour
{
    [SerializeField] private GameObject _particleDeath;
    public Action<Block> BlockDestroyed;

    public void DestroyBlock()
    {
        BlockDestroyed?.Invoke(this);

        GameObject particle = Instantiate(_particleDeath);
        particle.transform.position = transform.position;
        Destroy(gameObject);
    }
}
