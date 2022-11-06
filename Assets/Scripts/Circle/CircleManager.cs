using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CircleManager : MonoBehaviour
{
    [SerializeField] private Circle _prefabCircle;
    [SerializeField] private Transform cylinderTransform;
    private float lastCirclePos = 0.1f;

    private void Start()
    {
        CreateLayer();
    }

    private void CreateLayer()
    {
        lastCirclePos++;
        Circle newCircle = Instantiate(_prefabCircle, new Vector3(0, lastCirclePos, -0.09f), Quaternion.identity, transform);
        newCircle.LayerDamaged += OnLayerDamaged;
        newCircle.LayerDestroyed += OnLayerDestroy;
        cylinderTransform.position = new Vector3(0, lastCirclePos - 0.1f, 0);
    }

    private void OnLayerDamaged(Circle sender)
    {
        sender.LayerDamaged -= OnLayerDamaged;
        CreateLayer();
    }

    private void OnLayerDestroy(Circle sender)
    {
        sender.LayerDestroyed -= OnLayerDestroy;
        CameraMovement.instance.OnCircleDestroy();
    }
}
