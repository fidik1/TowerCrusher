using TMPro;
using UnityEngine;

public class BalanceTextUpdate : MonoBehaviour
{
    [SerializeField] private TMP_Text _textBalance;

    private void Start()
    {
        Balance.Instance.OnChangeMoney += UpdateText;
        UpdateText();
    }

    private void UpdateText() => _textBalance.text = Mathf.Round(Balance.Instance.Money).ToString();

    private void OnDestroy() => Balance.Instance.OnChangeMoney -= UpdateText;
}
