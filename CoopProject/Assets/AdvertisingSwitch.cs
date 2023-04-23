using System.Collections;
using Agava.YandexGames;
using UnityEngine;

public class AdvertisingSwitch : MonoBehaviour
{
   private float _duration = 300;

   private void Start() => StartCoroutine(ShowVideo());
   

   private IEnumerator ShowVideo()
   {
      var WaitForSecondsRealtime = new WaitForSecondsRealtime(_duration);
      
      while (true)
      {
         yield return WaitForSecondsRealtime;
         InterstitialAd.Show();
      }
   }
}
