using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _textGunPrice;
    [SerializeField] private TMP_Text _textLapPrice;
    [SerializeField] private TMP_Text _textMergePrice;
    [SerializeField] private TMP_Text _textMoneyMultiplayerPrice;

    [SerializeField] private TMP_Text _textBalance;

    private Bonuses _bonuses;

    private void Start()
    {
        _bonuses = Bonuses.instance;

        GunUpdate();
        LapUpdate();
        MergeUpdate();
        MoneyMultiplayer();
        OnBalanceUpdate();

        _bonuses.OnAddGun += GunUpdate;
        _bonuses.OnAddLap += LapUpdate;
        _bonuses.OnMerge += MergeUpdate;
        _bonuses.OnAddMoneyMultiplayer += MoneyMultiplayer;

        Balance.instance.OnChangeMoney += OnBalanceUpdate;
    }

    private void GunUpdate()
    {
        if (_bonuses.CurrentGuns <= _bonuses.MaxGuns)
            _textGunPrice.text = "$ " + Mathf.Round(_bonuses.PriceGun).ToString();
        else
            _textGunPrice.text = "MAX";
    }

    private void LapUpdate()
    {
        if (_bonuses.CurrentLaps <= _bonuses.MaxLaps)
            _textLapPrice.text = "$ " + Mathf.Round(_bonuses.PriceLap).ToString();
        else
            _textLapPrice.text = "MAX";
    }

    private void MergeUpdate()
    {
        if (_bonuses.CurrentGuns > _bonuses.MinGunsToMerge)
            _textMergePrice.text = "$ " + Mathf.Round(_bonuses.PriceMerge).ToString();
        else
            _textMergePrice.text = "NEED AT LEAST 3 TURRET";
    }

    private void MoneyMultiplayer()
    {
        _textMoneyMultiplayerPrice.text = "$ " + Mathf.Round(_bonuses.PriceMoneyMultiplayer).ToString();
    }

    private void OnBalanceUpdate()
    {
        _textBalance.text = Mathf.Round(Balance.instance.Money).ToString();
    }
}
