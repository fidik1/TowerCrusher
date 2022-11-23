using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private Image _image;

    [SerializeField] private Color32 _colorEnabled;
    [SerializeField] private Color32 _colorDisabled;

    private Bonus _linkedBonus;

    public void Init(Bonus bonus, Color color, string text)
    {
        _colorEnabled = color;
        _text.text = text;
        _linkedBonus = bonus;
        _linkedBonus.LevelRisen += UpdateText;
        Balance.Instance.OnChangeMoney += UpdateText;
        name = bonus.Data.BonusName;
        UpdateText();
    }

    public void Click() => _linkedBonus.Upgrade();

    private void UpdateText()
    {
        _image.color = _linkedBonus.EnoughMoney && _linkedBonus.EnoughLevel && _linkedBonus.Data.Enabled ? _colorEnabled : _colorDisabled;
        _textPrice.text = _linkedBonus.EnoughLevel ? "$ " + Mathf.Round(_linkedBonus.Price).ToString() : "MAX";
    }

    private void OnDestroy()
    {
        _linkedBonus.LevelRisen -= UpdateText;
        Balance.Instance.OnChangeMoney -= UpdateText;
    }
}
