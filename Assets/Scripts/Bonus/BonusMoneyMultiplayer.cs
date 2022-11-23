using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bonus/Money Multiplayer", fileName = "Bonus")]
public class BonusMoneyMultiplayer : BonusData
{
    public override void Execute()
    {
        
    }

    public override bool Enabled { get { return true; } }
}
