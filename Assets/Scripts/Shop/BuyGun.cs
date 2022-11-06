using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGun : MonoBehaviour
{
    [SerializeField] private GameObject _prefabGun;
    [SerializeField] private Transform _guns;
    [SerializeField] private float _offset;
    private Transform _lastGun;

    private void Start()
    {
        _lastGun = _guns.GetChild(_guns.childCount - 1);

        Bonuses.instance.OnAddGun += AddGun;
    }

    private void AddGun()
    {
        GameObject _gun = Instantiate(_prefabGun, _guns);
        _gun.transform.position = _lastGun.position;
        _gun.transform.eulerAngles = new Vector3(0, _lastGun.eulerAngles.y - _offset, 0);
        _lastGun = _guns.GetChild(_guns.childCount - 1);
    }
}
