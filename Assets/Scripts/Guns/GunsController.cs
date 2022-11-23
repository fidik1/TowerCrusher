using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;
using DG.Tweening;

public class GunsController
{
    private readonly List<Gun> _gunList = new();
    private readonly Transform _parent;
    private readonly TypeGun _typeLastLevelGun;
    public int maxLevelCount;
    private const float _offset = 30;

    private readonly GunData[] _gunData;

    public GunsController(Transform parent, GunData[] gunData)
    {
        _typeLastLevelGun = System.Enum.GetValues(typeof(TypeGun)).Cast<TypeGun>().Last();
        _parent = parent;
        _gunData = gunData;
    }

    private List<Gun> ExtractGuns()
    {
        TypeGun[] types = System.Enum.GetValues(typeof(TypeGun)).Cast<TypeGun>().ToArray();

        List<Gun> max = new();

        foreach (TypeGun type in types)
        {
            List<Gun> gunList = new();
            for (int i = 0; i < _gunList.Count; i++)
            {
                if (_gunList[i].typeGun == type)
                    gunList.Add(_gunList[i]);
            }

            if (max.Count < gunList.Count)
                max = gunList;
        }
        Debug.Log(max.Count);
        return max;
    }
    //_gunList.GroupBy(i => i).Where(g => g.Count() > 3).Select(y => y.Key).ToList();
    public bool ReadyToMerge { get; private set; }

    public void AddGun(Gun newGun)
    {
        _gunList.Add(newGun);
        if (newGun.typeGun == _typeLastLevelGun)
            maxLevelCount++;

        List<Gun> listGun = ExtractGuns();
        ReadyToMerge = listGun.Count >= 3 && listGun[0].typeGun != _typeLastLevelGun;
    }

    public void RemoveGun(Gun gun)
    {
        _gunList.Remove(gun);
        if (gun.typeGun == _typeLastLevelGun)
            maxLevelCount--;
        List<Gun> listGun = ExtractGuns();
        if (listGun.Count < 3) return;
        ReadyToMerge = listGun[0].typeGun != _typeLastLevelGun;
    }

    public Gun CreateGun(GunData prototype, bool isFirst = false)
    {
        Gun gun = Gun.Instantiate(prototype.prefabGun, new Vector3(0, Camera.main.transform.position.y, 0), Quaternion.Euler(0, 0, 0), _parent).GetComponent<Gun>();
        if (!isFirst)
        {
            if (_gunList.Count > 0)
            {
                gun.transform.DOMove(_gunList[0].transform.position, 0.5f).SetLink(gun.gameObject);
                gun.transform.DORotate(new Vector3(0, _gunList[^1].transform.eulerAngles.y - _offset, 0), 0.5f);
            }
            else
            {
                gun.transform.DOMove(new Vector3(0, Camera.main.transform.position.y - 11f, 0), 0.5f).SetLink(gun.gameObject);
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
                gun.transform.SetPositionAndRotation(new Vector3(0, Camera.main.transform.position.y - 11f, 0), Quaternion.Euler(0, 0, 0));

            AddGun(gun);
            return gun;
        }
    }

    public List<Gun> GetGuns()
    {
        return _gunList;
    }

    public void BonusLapExecuted(Bonus bonus)
    {
        foreach (Gun gun in _gunList)
        {
            gun.gunMovement.UpdateLaps(bonus.CurrentLevel);
        }
    }

    private GunMovement _gunMovement;
    private int index;

    public void Merge()
    {
        List<Gun> mergeGunList = World.Instance.gunsController.ExtractGuns();
        for (int i = 0; i < 3; i++)
        {
            mergeGunList[i].gunMovement.OnMerge();
            RemoveGun(mergeGunList[i]);
        }
        index = (int)mergeGunList[0].typeGun;

        _gunMovement = mergeGunList[0].gunMovement;

        World.ExecuteWithDelay(_gunMovement._timeToMerge, OnMerge);
    }

    private void OnMerge() => CreateGun(_gunData[index + 1]);
}
