using System;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public float Money { get; private set; }
    public static Balance Instance;

    public Action OnChangeMoney;

    [SerializeField] private float incomeFromBlock;
    private float moneyMultiplayer;

    private void Awake() => Instance = this;

    private void Start() => ChangeBalance(PlayerPrefs.GetFloat("Balance"));

    public void ChangeBalance(float price)
    {
        Money += price;
        OnChangeMoney?.Invoke();
    }

    public void IncreaseMoneyMultiplayer(int moneyMultiplayer)
    {
        this.moneyMultiplayer += moneyMultiplayer;
    }

    public void OnDestroyBlock() => ChangeBalance(incomeFromBlock * moneyMultiplayer * 0.1f + 0.9f);
}
