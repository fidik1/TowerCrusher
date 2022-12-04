using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsMerge
{
    private GunMovement _gunMovement;
    private int _index;
    private GunsController _gunsController;
    
    private readonly GunData[] _gunData;

    public GunsMerge(GunData[] gunData) => _gunData = gunData;

    public void Merge()
    {
        _gunsController = World.Instance.GunsController;
        List<Gun> mergeGunList = _gunsController.ExtractGuns();
        for (int i = 0; i < 3; i++)
        {
            mergeGunList[i].GunMovement.OnMerge();
            _gunsController.RemoveGun(mergeGunList[i]);
        }
        _index = (int)mergeGunList[0].TypeGun;

        _gunMovement = mergeGunList[0].GunMovement;

        World.ExecuteWithDelay(_gunMovement._timeToMerge, OnMerge);
    }

    private void OnMerge() => _gunsController.CreateGun(_gunData[_index + 1]);
}
