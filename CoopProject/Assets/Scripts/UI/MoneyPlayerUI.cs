using Reflex;
using Reflex.Scripts.Attributes;
using TMPro;
using UnityEngine;

public class MoneyPlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textUI;
    [SerializeField] private PlayerWallet _playerWallet;
    
    [Inject]
    private void Inject(Container container) => _playerWallet = container.Resolve<PlayerWallet>();

    private void OnEnable() => _playerWallet.SetCoinValue += DisplayPlayerWalletCoin;
    
    private void DisplayPlayerWalletCoin() => _textUI.text = $"{_playerWallet.Coins}";
    
    private void OnDisable() => _playerWallet.SetCoinValue -= DisplayPlayerWalletCoin;
}
