using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bonuses : MonoBehaviour
{
    public int CurrentGuns { get; private set; } = 1;
    [field: SerializeField] public int MaxGuns { get; private set; }
    public int CurrentLaps { get; private set; }
    [field: SerializeField] public int MaxLaps { get; private set; }
    public int MinGunsToMerge { get; private set; } = 3;
    public float MoneyMultiplayer { get; private set; } = 1;

    [field: SerializeField] public float PriceGun { get; private set; }
    [field: SerializeField] public float PriceLap { get; private set; }
    [field: SerializeField] public float PriceMerge { get; private set; }
    [field: SerializeField] public float PriceMoneyMultiplayer { get; private set; }

    public Action OnAddGun;
    public Action OnAddLap;
    public Action OnMerge;
    public Action OnAddMoneyMultiplayer;

    public static Bonuses instance;

    private void Awake()
    {
        instance = this;
    }

    public void AddGun()
    {
        if (Balance.instance.Money >= PriceGun && CurrentGuns <= MaxGuns)
        {
            Balance.instance.ChangeBalance(-PriceGun);
            PriceGun *= 1.25f;
            CurrentGuns++;
            OnAddGun?.Invoke();
        }
    }

    public void AddLap()
    {
        if (Balance.instance.Money >= PriceLap && CurrentLaps <= MaxLaps)
        {
            Balance.instance.ChangeBalance(-PriceLap);
            PriceLap *= 1.25f;
            CurrentLaps++;
            OnAddLap?.Invoke();
        }
    }

    public void Merge()
    {
        if (Balance.instance.Money >= PriceMerge && CurrentGuns > MinGunsToMerge)
        {
            Balance.instance.ChangeBalance(-PriceMerge);
            PriceMerge *= 1.25f;
            OnMerge?.Invoke();
        }
    }
    
    public void AddMoneyMultiplayer()
    {
        if (Balance.instance.Money >= PriceMoneyMultiplayer)
        {
            Balance.instance.ChangeBalance(-PriceMoneyMultiplayer);
            PriceMoneyMultiplayer *= 1.25f;
            MoneyMultiplayer += 0.1f;
            OnAddMoneyMultiplayer?.Invoke();
        }
    }
}
