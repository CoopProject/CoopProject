using Reflex;
using Reflex.Scripts.Attributes;
using TMPro;
using UnityEngine;

public class MoneyPlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textUI;
    [SerializeField] private Player _player;
    
    [Inject]
    private void Inject(Container container) => _player = container.Resolve<Player>();

    private void OnEnable() => _player.SetCoinValue += DisplayPlayerCoin;
    
    private void DisplayPlayerCoin() => _textUI.text = $"{_player.Coins}";
    
    private void OnDisable() => _player.SetCoinValue -= DisplayPlayerCoin;
}
