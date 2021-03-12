using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel, _textStart;
    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void GameStarted()
    {
        _textStart.SetActive(false);
    }
}
