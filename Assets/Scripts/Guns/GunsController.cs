using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using DG.Tweening;

public class GunsController
{
    private readonly Camera _camera;
    private readonly List<Gun> _gunList = new();
    private readonly Transform _parent;
    private readonly TypeGunEnum _typeLastLevelGun;
    public int maxLevelCount;
    private const float _offset = 30;

    public GunsController(Camera camera, Transform parent)
    {
        _camera = camera;
        _typeLastLevelGun = Enum.GetValues(typeof(TypeGunEnum)).Cast<TypeGunEnum>().Last();
        _parent = parent;
    }

    public List<Gun> ExtractGuns()
    {
        TypeGunEnum[] types = Enum.GetValues(typeof(TypeGunEnum)).Cast<TypeGunEnum>().ToArray();

        List<Gun> max = new();

        foreach (TypeGunEnum type in types)
        {
            List<Gun> gunList = new();
            for (int i = 0; i < _gunList.Count; i++)
            {
                if (_gunList[i].TypeGun == type)
                    gunList.Add(_gunList[i]);
            }

            if (max.Count < gunList.Count)
                max = gunList;
        }
        return max;
    }

    public bool ReadyToMerge { get; private set; }

    public void AddGun(Gun newGun)
    {
        _gunList.Add(newGun);
        if (newGun.TypeGun == _typeLastLevelGun)
            maxLevelCount++;

        List<Gun> listGun = ExtractGuns();
        ReadyToMerge = listGun.Count >= 3 && listGun[0].TypeGun != _typeLastLevelGun;
    }

    public void RemoveGun(Gun gun)
    {
        _gunList.Remove(gun);
        if (gun.TypeGun == _typeLastLevelGun)
            maxLevelCount--;
        List<Gun> listGun = ExtractGuns();
        if (listGun.Count < 3) return;
        ReadyToMerge = listGun[0].TypeGun != _typeLastLevelGun;
    }

    public Gun CreateGun(GunData prototype, bool isFirst = false)
    {
        Gun gun = Gun.Instantiate(prototype.prefabGun, new Vector3(0, _camera.transform.position.y, 0), Quaternion.Euler(0, 0, 0), _parent).GetComponent<Gun>();
        if (!isFirst)
        {
            if (_gunList.Count > 0)
            {
                gun.transform.DOMove(_gunList[0].transform.position, 0.5f).SetLink(gun.gameObject);
                gun.transform.DORotate(new Vector3(0, _gunList[^1].transform.eulerAngles.y - _offset, 0), 0.5f);
                gun.GunMovement.Init(_gunList[^1].GunMovement.CurrentLap);
            }
            else
            {
                gun.transform.DOMove(new Vector3(0, _camera.transform.position.y - 11f, 0), 0.5f).SetLink(gun.gameObject);
                gun.transform.DORotate(Vector3.zero, 0.5f);
            }

            AddGun(gun);
            return gun;
        }
        else
        {
            if (_gunList.Count > 0)
                gun.transform.SetPositionAndRotation(_gunList[^1].transform.position, Quaternion.Euler(0, _gunList[^1].transform.eulerAngles.y - _offset, 0));
            else
                gun.transform.SetPositionAndRotation(new Vector3(0, _camera.transform.position.y - 11f, 0), Quaternion.Euler(0, 0, 0));

            AddGun(gun);
            return gun;
        }
    }

    public List<Gun> GetGuns()
    {
        return _gunList;
    }
}
