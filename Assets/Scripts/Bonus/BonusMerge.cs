using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

[CreateAssetMenu(menuName = "Bonus/Merge", fileName = "Bonus")]
public class BonusMerge : BonusData
{
    public override void Execute()
    {
        World.Instance.GunsMerge.Merge();
    }

    public override bool Enabled { get { return World.Instance.GunsController.ReadyToMerge; } }
}
