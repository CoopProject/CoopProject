using System;
using UnityEngine;

namespace DefaultNamespace
{
    public static class GamePause
    {

        public static event Action OnGamePause;
        public static event Action OffGamePause;
        
        private static void Active()
        {
            Time.timeScale = 0;
        }

        private static void Off()
        {
            Time.timeScale = 1f;
        }

        public static void OnGamePauseActive()
        {
            OnGamePause += Active;
            OnGamePause?.Invoke();
            OnGamePause -= Active;
        }

        public static void OffGamePauseActive()
        {
            OffGamePause += Off;
            OffGamePause?.Invoke();
            OffGamePause -= Off;
        }

        public static void IntarstialClose(bool close)
        {
            if (close)
            {
                OffGamePause += Off;
                OffGamePause?.Invoke();
                OffGamePause -= Off;     
            }
            
        }
    }
}