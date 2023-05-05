using Agava.YandexGames;
using DefaultNamespace;
using UnityEngine;

public class AdvertisingSwitch : MonoBehaviour
{
   private float _duration = 300;
   private float _durationMax = 300;
   
   private void FixedUpdate()
   {
      _duration -= Time.deltaTime;
      
      if (_duration < 0)
      {
         InterstitialAd.Show(GamePause.OnGamePauseActive,GamePause.IntarstialClose,null);
         _duration = _durationMax;
      }   
   }
}
