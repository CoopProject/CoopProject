using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallet : MonoBehaviour
{
    private int _coins = 0;
    public int Coins => _coins;
    public event Action SetCoinValue;
    public event Action<int> OnPlayerScoreUpdated;

    private void Start()
    {
        LoadData();
        SetCoinValue?.Invoke();
        _coins = 10000;
    }

    public void SetCoinsValue(int coins)
    {
        if (coins > 0)
        {
            _coins += coins;
            OnPlayerScoreUpdated?.Invoke(coins);
        }
        
        SetCoinValue?.Invoke();
        SaveData();
    }
    
    public void SellCoints(int price)
    {
        if (price > 0 && _coins >= price)
            _coins -= price;
        
        SetCoinValue?.Invoke();
        SaveData();
    }

    private void SaveData() => PlayerPrefs.SetInt("Coins",_coins);

    private void LoadData() => _coins = PlayerPrefs.GetInt("Coins",0);
}
