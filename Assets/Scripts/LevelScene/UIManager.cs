using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel, _textStart;
    [SerializeField]
    private Text _coinStatic, _coinDynamic;

    private void Start()
    {
        _coinStatic.text = "Coins :";
    }

    public void UpdateCoins(int coins)
    {
        _coinDynamic.text = coins.ToString();
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void GameStarted()
    {
        _textStart.SetActive(false);
    }
}
