using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    private GunsController _gunsController;
    private BonusManager _bonusManager;

    private void Start()
    {
        _gunsController = World.Instance.GunsController;
        _bonusManager = World.Instance.BonusManager;
        print(_bonusManager);
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Balance", Balance.Instance.Money);

        TypeGunEnum[] types = System.Enum.GetValues(typeof(TypeGunEnum)).Cast<TypeGunEnum>().ToArray();

        foreach (TypeGunEnum type in types)
        {
            List<Gun> guns = _gunsController.GetGuns();
            int a = _gunsController.GetGuns().Where(p => p.TypeGun == type).Count();
            PlayerPrefs.SetInt(type.ToString(), a);
        }

        for (int i = 0; i < 4; i++)
        {
            PlayerPrefs.SetInt(_bonusManager.GetBonus(i).Data.BonusName, _bonusManager.GetBonus(i).CurrentLevel);
        }
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause) Save();
    }

    private void OnApplicationQuit() => Save();
}
