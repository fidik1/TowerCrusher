using UnityEngine;
using System;

[Serializable]
public class Bonus
{
    [field: SerializeField] public BonusData Data { get; private set; }
    [field: SerializeField] public int CurrentLevel { get; private set; }
    public float Price { get { return Mathf.Pow(Data.PriceMultiplayer, CurrentLevel) * Data.BasePrice; } }
    [field: SerializeField] public float PriceMultiplayer { get; private set; }
    public Action LevelRisen;

    public Bonus(BonusData bonusData)
    {
        Data = bonusData;
        CurrentLevel = PlayerPrefs.GetInt(Data.BonusName);
        
    }

    public bool EnoughMoney { get { return Balance.Instance.Money >= Price; } }
    public bool EnoughLevel { get { return CurrentLevel < Data.MaxLevel; } }

    public void Upgrade()
    {
        if (EnoughMoney && EnoughLevel && Data.Enabled)
        {
            Data.Execute();
            Balance.Instance.ChangeBalance(-Price);
            CurrentLevel++;
            LevelRisen?.Invoke();
        }
    }
}
