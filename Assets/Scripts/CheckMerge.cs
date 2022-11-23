using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CheckMerge : MonoBehaviour
{
    private int CountOfIdenticalGuns;
    [SerializeField] private GunsController _gunsController;

    public void Check()
    {
        Invoke(nameof(CheckCount), 0.1f);
    }

    private int CheckCount()
    {
        if (_gunsController.GetGuns().Count <= 0)
        {
            CountOfIdenticalGuns = 0;
            return CountOfIdenticalGuns;
        }
        else
        {
            List<Gun> guns = _gunsController.GetGuns().ToList();
            int count = guns.GroupBy(g => g.tag).Max(ig => ig.Count());
            CountOfIdenticalGuns = count;
            return CountOfIdenticalGuns;
        }
    }
}
