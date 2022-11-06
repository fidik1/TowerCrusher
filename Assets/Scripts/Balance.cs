using System;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public float Money { get; private set; }
    public static Balance instance;

    public Action OnChangeMoney;

    [SerializeField] private float incomeFromBlock;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeBalance(float price)
    {
        Money += price;
        OnChangeMoney?.Invoke();
    }

    public void OnDestroyBlock()
    {
        ChangeBalance(incomeFromBlock * Bonuses.instance.MoneyMultiplayer);
    }
}
