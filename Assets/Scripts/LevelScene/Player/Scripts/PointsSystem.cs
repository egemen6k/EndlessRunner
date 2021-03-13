using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public static int coins;
    private int previousCoins;
    private UIManager _uiManager;

    void Start()
    {
        coins = 0;

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("UI Manager is null.");
        }
    }

    private void Update()
    {
        if (coins != previousCoins)
        {
            _uiManager.UpdateCoins(coins);
            previousCoins = coins;
        }
    }

}
