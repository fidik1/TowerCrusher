using DG.Tweening;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(DestroyCoin), 3);
    }

    private void DestroyCoin()
    {
        transform.DOScale(new Vector3(0, 0, 0), 0.5f).SetLink(gameObject);
        Destroy(gameObject, 0.52f);
    }
}
