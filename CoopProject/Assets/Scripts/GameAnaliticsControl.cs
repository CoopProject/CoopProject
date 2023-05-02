using GameAnalyticsSDK;
using UnityEngine;

public class GameAnaliticsControl : MonoBehaviour
{
    private void Awake()
    {
        GameAnalytics.Initialize();
    }
}
