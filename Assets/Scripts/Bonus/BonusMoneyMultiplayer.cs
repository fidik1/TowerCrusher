using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bonus/Money Multiplayer", fileName = "Bonus")]
public class BonusMoneyMultiplayer : BonusData
{
    public override void Execute()
    {
        Balance.Instance.IncreaseMoneyMultiplayer(World.Instance.BonusManager.GetBonus(3).CurrentLevel);
    }

    public override bool Enabled { get { return true; } }
}
