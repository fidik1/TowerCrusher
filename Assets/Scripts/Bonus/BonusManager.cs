using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private BonusButton _buttonPrefab;
    [SerializeField] private Color32[] _buttonColor;
    [SerializeField] private string[] _buttonText;
    [SerializeField] private List<BonusData> _bonusDataList;
    private List<Bonus> _bonusList;

    private void Start()
    {
        _bonusList = new List<Bonus>();
        int i = 0;
        foreach (BonusData bonusData in _bonusDataList)
        {
            Bonus newBonus = new (bonusData);
            _bonusList.Add(newBonus);
            BonusButton button = Instantiate(_buttonPrefab, transform);
            button.Init(newBonus, _buttonColor[i], _buttonText[i]);
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
