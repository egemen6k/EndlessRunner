using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private UIManager _uiManager;
    private TileManager _tileManager;
    public bool _isGameStarted = false;

    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
        {
            Debug.LogError("UI Manager is null");
        }
        _tileManager = GameObject.Find("TileManager").GetComponent<TileManager>();
        if (_tileManager == null)
        {
            Debug.LogError("Tile Manager is null");
        }

        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Input.touchCount > 0 || Input.anyKey)
        {
            _isGameStarted = true;
            _uiManager.GameStarted();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _uiManager.GameOver();
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
