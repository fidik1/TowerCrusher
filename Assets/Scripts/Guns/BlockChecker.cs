using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BlockChecker : MonoBehaviour
{
    [SerializeField] private List<Collider> colliders;
    private Collider closest;

    private float distance;

    private const string blockTag = "BlockParent";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(blockTag)) return;
        colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(blockTag)) return;
        colliders = colliders.Where(p => p != other).ToList();
    }

    public Vector3 GetVector()
    {
        distance = Mathf.Infinity;
        Vector3 pos = transform.position;
        colliders = colliders.Where(p => p != null).ToList();
        closest = null;
        foreach (Collider obj in colliders)
        {
            if (obj == null) continue;
            float curDistance = (obj.transform.position - pos).sqrMagnitude;
            if (curDistance < distance)
            {
                closest = obj;
                distance = curDistance;
            }
        }

        if (closest.transform.position != null)
        {
            colliders.Remove(closest);
            return closest.transform.position;
        }
        else
            return Vector3.zero;
    }
}
