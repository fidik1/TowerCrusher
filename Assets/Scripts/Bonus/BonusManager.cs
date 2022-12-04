using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private List<BonusButton> _bonusButtons;
    [SerializeField] private List<BonusData> _bonusDataList;
    private List<Bonus> _bonusList;

    private void Awake()
    {
        _bonusList = new List<Bonus>();
        int i = 0;
        foreach (BonusData bonusData in _bonusDataList)
        {
            Bonus newBonus = new (bonusData);
            _bonusList.Add(newBonus);
            _bonusButtons[i].Init(newBonus);
            i++;
        }
    }

    public Bonus GetBonus<T>() where T : BonusData
    {
        return _bonusList.FirstOrDefault(p => p.Data is T);
    }

    public Bonus GetBonus(BonusData data)
    {
        return _bonusList.FirstOrDefault(p => p.Data == data);
    }

    public Bonus GetBonus(int i)
    {
        return _bonusList[i];
    }
}
