using UnityEngine;
using System;

public class Circle : MonoBehaviour
{
    [SerializeField] Block[] blocks;
    public Action<Circle> LayerDamaged;
    public Action<Circle> LayerDestroyed;
    private int currentBlocks;

    private void Awake()
    {
        foreach (Block block in blocks)
        {
            block.BlockDestroyed += OnBlockDestroyed;
        }
        currentBlocks = blocks.Length;
    }

    private void OnBlockDestroyed(Block block)
    {
        currentBlocks--;
        block.BlockDestroyed -= OnBlockDestroyed;
        LayerDamaged?.Invoke(this);
        if (currentBlocks == 0) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (CameraMovement.Instance == null) return;
        LayerDestroyed?.Invoke(this);
    }
}
