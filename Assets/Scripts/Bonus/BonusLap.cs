using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bonus/Lap", fileName = "Bonus")]
public class BonusLap : BonusData
{
    public override void Execute()
    {
        World.Instance.LapsController.BonusLapExecuted();
    }

    public override bool Enabled { get { return true; } }
}
