using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private CharacterController _cc;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _cc = GetComponent<CharacterController>();
        if (_cc == null)
        {
            Debug.LogError("Character Controller is null.");
        }

        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gameManager == null)
        {
            Debug.LogError("GameManager is null.");
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Obstacle"))
        {
            _gameManager.GameOver();
        }
    }
}
