using System;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public float Money { get; private set; }
    public static Balance Instance;

    public Action OnChangeMoney;

    [SerializeField] private float incomeFromBlock;

    private void Awake() => Instance = this;

    private void Start() => ChangeBalance(PlayerPrefs.GetFloat("Balance"));

    public void ChangeBalance(float price)
    {
        Money += price;
        OnChangeMoney?.Invoke();
        print("Invoked");
    }

    public void OnDestroyBlock() => ChangeBalance(incomeFromBlock * World.Instance.bonusManager.GetBonus(3).CurrentLevel * 0.1f + 0.9f);
}
