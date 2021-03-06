using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _laneDistance = 4f;
    [SerializeField]
    private float _speed = 8f;
    private float _maxSpeed = 40f;

    private CharacterController _cc;
    private GameManager _gm;
    private IGetHorizontal GetHorizontal;
    private IGetVertical GetVertical;
    private IGetPosition GetPosition;
    private Vector3 _velocity;
    private int _desiredLane = 1; //0: left, 1: middle, 2: right

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        if (_cc == null)
        {
            Debug.LogError("Character Controller is null.");
        }

        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gm == null)
        {
            Debug.LogError("Game Manager is null.");
        }

        GetHorizontal = GetComponent<IGetHorizontal>();
        if (GetHorizontal == null)
        {
            Debug.LogError("Input Interface is null");
        }

        GetVertical = GetComponent<IGetVertical>();
        if (GetVertical == null)
        {
            Debug.LogError("Jumping interface is null");
        }

        GetPosition = GetComponent<IGetPosition>();
        if (GetPosition == null)
        {
            Debug.LogError("Lane Selection Interface is null");
        }
    }

    private void Update()
    {
        if (!_gm._isGameStarted)
        {
            return;
        }

        _velocity = Vector3.forward * _speed;
        if (_speed < _maxSpeed)
        {
            _speed += 0.1f * Time.deltaTime;
        }

        _desiredLane = GetHorizontal.GetLane(_desiredLane);
        transform.position = GetPosition.MoveThere(_desiredLane, _laneDistance);
        _cc.center = _cc.center;
        _velocity = GetVertical.Jump(_velocity);
        _cc.Move(_velocity * Time.deltaTime);
    }
}
