using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bonus/Lap", fileName = "Bonus")]
public class BonusLap : BonusData
{
    public override void Execute()
    {
        Bonus bonus = World.Instance.bonusManager.GetBonus(this);
        World.Instance.gunsController.BonusLapExecuted(bonus);
    }

    public override bool Enabled { get { return true; } }
}
