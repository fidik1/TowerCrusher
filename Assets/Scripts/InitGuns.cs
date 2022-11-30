using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class InitGuns : MonoBehaviour
{
    private GunsController _gunsController;
    [SerializeField] private GunData[] _gunData;
    private bool isCreated;

    public void Start()
    {
        _gunsController = World.Instance.GunsController;

        TypeGunEnum[] types = System.Enum.GetValues(typeof(TypeGunEnum)).Cast<TypeGunEnum>().ToArray();

        foreach (TypeGunEnum type in types)
        {
            for (int i = 0; i < PlayerPrefs.GetInt(type.ToString()); i++)
            {
                isCreated = true;
                _gunsController.CreateGun(_gunData[(int)type], true);
            }
        }

        if (!isCreated)
            _gunsController.CreateGun(_gunData[0]);
    }
}
