using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusData : ScriptableObject
{
    [field: SerializeField] public float BasePrice { get; private set; } = 25;
    [field: SerializeField] public float PriceMultiplayer { get; private set; } = 1.5f;
    [field: SerializeField] public float MaxLevel { get; private set; } = 999;
    [field: SerializeField] public string BonusName { get; private set; } = "Bonus";
    public abstract bool Enabled { get; }
    public abstract void Execute();
}
