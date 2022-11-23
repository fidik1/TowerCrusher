using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BuyMerge : MonoBehaviour
{
    /*private Bonuses _bonuses;
    [SerializeField] private GunsController _gunsController;

    [SerializeField] private GameObject _prefabParticle;
    [SerializeField] private Transform _parentGuns;
    [SerializeField] private GameObject[] _prefabsGun;

    private Vector3 _pos;
    private GunMovement _gunMovement;

    [SerializeField] private GunData _gunData;

    private readonly int _index;

    private void Start()
    {
        _bonuses = World.Instance.bonuses;
        //_bonuses.Merge += Merge;
    }

    private void Merge()
    {
        if (_gunsController.ExtractGuns() == null)
            return;
        else
        {
            List<Gun> guns = _gunsController.ExtractGuns();

            for (int i = 0; i < 3; i++)
            {
                guns[i].gunMovement.OnMerge();
            }

            _gunMovement = guns[0].GetComponent<GunMovement>();
            Invoke(nameof(AddGunByMerge), _gunMovement._timeToMerge);
        }
    }

    private void AddGunByMerge()
    {
        GameObject particle = Instantiate(_prefabParticle, _parentGuns);
        particle.transform.position = _gunMovement._targetPos;
        
        Gun gun = _gunsController.CreateGun(_gunData);
        gun.transform.DOMove(new Vector3(0, Camera.main.transform.position.y - 11f, 0), 0.5f).SetLink(gun.gameObject);
    }

    private void OnDestroy()
    {
        //_bonuses.Merge -= Merge;
    }*/
}
