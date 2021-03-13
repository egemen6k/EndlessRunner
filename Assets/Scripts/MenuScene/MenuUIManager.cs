using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    MenuManager _menuManager;

    private void Start()
    {
        _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        if (_menuManager == null)
        {
            Debug.LogError("Menu Manager is null.");
        }
    }
    public void GameStart()
    {
        _menuManager.GameStart();
    }

    public void GameQuit()
    {
        _menuManager.GameQuit();
    }
}
