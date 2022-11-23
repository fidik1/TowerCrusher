using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Bonuses
{
    /*public int CurrentGuns { get; private set; } = 1;
    public int MaxGuns { get; private set; }
    public int CurrentLaps { get; private set; }
    public int MaxLaps { get; private set; }
    public int MinGunsToMerge { get; private set; } = 3;
    public int CurrentLevelMerge { get; private set; } = 1;
    public float MoneyMultiplayer { get; private set; } = 1;
    public int CurrentLevelMoneyMultiplayer { get; private set; } = 1;
    public int CountOfIdenticalGuns { get; private set; }*/
    /*public float PriceLap { get; internal set; }
    public float PriceGun { get; internal set; }
    public float PriceMerge { get; private set; }
    public float PriceMoneyMultiplayer { get; internal set; }*/

    //private float _priceAdd = 1.5f;
    //[SerializeField] private GunData[] _gunData;
    //public Action AddLap;
    //public Action Merge;

    /*private Balance _balance;
    private GunsController _gunsController;*/
/*
    public Bonuses()
    {
        _balance = Balance.Instance;
        InitBonuses();
    }

    private void InitBonuses()
    {
        CurrentGuns = PlayerPrefs.GetInt("CurrentGuns", 1);
        PriceGun *= Mathf.Pow(_priceAdd, CurrentGuns - 1);
        CurrentLaps = PlayerPrefs.GetInt("CurrentLaps", 0);
        PriceLap *= Mathf.Pow(_priceAdd, CurrentLaps);
        CurrentLevelMerge = PlayerPrefs.GetInt("CurrentMerge", 1);
        PriceMerge *= Mathf.Pow(_priceAdd, CurrentLevelMerge - 1);
        CurrentLevelMoneyMultiplayer = PlayerPrefs.GetInt("CurrentMoneyMultiplayer", 1);
        PriceMoneyMultiplayer *= Mathf.Pow(_priceAdd, CurrentLevelMoneyMultiplayer - 1);
        MoneyMultiplayer += 0.1f * CurrentLevelMoneyMultiplayer;
        MoneyMultiplayer -= 0.1f;
    }

    public void OnAddGun()
    {
        if (_balance.Money >= PriceGun && CurrentGuns <= MaxGuns && _gunsController.maxLevelCount <= MaxGuns)
        {
            if (_gunsController.maxLevelCount == MaxGuns && CurrentGuns > MinGunsToMerge+1) return;
            _balance.ChangeBalance(-PriceGun);
            PriceGun *= _priceAdd;
            CurrentGuns++;
            _gunsController.AddGun(_gunsController.CreateGun(_gunData[0]));
        }
    }

    public void OnAddLap()
    {
        if (_balance.Money >= PriceLap && CurrentLaps <= MaxLaps)
        {
            _balance.ChangeBalance(-PriceLap);
            PriceLap *= _priceAdd;
            CurrentLaps++;
            AddLap?.Invoke();
        }
    }

    public void OnMerge()
    {
        if (_balance.Money >= PriceMerge && CountOfIdenticalGuns >= MinGunsToMerge)
        {
            _balance.ChangeBalance(-PriceMerge);
            PriceMerge *= _priceAdd;
            CurrentLevelMerge++;
            Merge?.Invoke();
            CurrentGuns -= MinGunsToMerge-1;
        }
    }

    public void OnAddMoneyMultiplayer()
    {
        if (_balance.Money >= PriceMoneyMultiplayer)
        {
            _balance.ChangeBalance(-PriceMoneyMultiplayer);
            PriceMoneyMultiplayer *= _priceAdd;
            CurrentLevelMoneyMultiplayer++;
            MoneyMultiplayer += 0.1f;
        }
    }*/
}
