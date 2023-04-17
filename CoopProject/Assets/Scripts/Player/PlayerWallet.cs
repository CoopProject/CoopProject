using System;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    private int _coins = 0;
    
    public int Coins => _coins;
    public event Action SetCoinValue;
    
    public void SetCoinsValue(int coins)
    {
        if (coins > 0)
            _coins += coins;
        
        SetCoinValue?.Invoke();
    }

    public void SellCoints(int price)
    {
        if (price > 0 && _coins >= price)
            _coins -= price;
        
        SetCoinValue?.Invoke();
    }
}
