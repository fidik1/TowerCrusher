using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bonus/Gun", fileName = "Bonus")]
public class BonusGun : BonusData
{
    public GunData gunData;
    public override void Execute()
    {
        World.Instance.GunsController.CreateGun(gunData);
    }

    public override bool Enabled { get { return true; } }
}
