using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverPanel;
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
