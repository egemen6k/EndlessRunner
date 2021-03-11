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

    private CharacterController _cc;
    private IGetInput GetInput;
    private IGetLane GetLane;
    private IGetJump GetJump;
    private Vector3 _velocity;
    private int _desiredLane = 1; //0: left, 1: middle, 2: right

    void Start()
    {
        _cc = GetComponent<CharacterController>();
        if (_cc == null)
        {
            Debug.LogError("Character Controller is null.");
        }

        GetInput = GetComponent<IGetInput>();
        if (GetInput == null)
        {
            Debug.LogError("Input Interface is null");
        }

        GetLane = GetComponent<IGetLane>();
        if (GetLane == null)
        {
            Debug.LogError("Lane Selection Interface is null");
        }

        GetJump = GetComponent<IGetJump>();
        if (GetJump == null)
        {
            Debug.LogError("Jumping interface is null");
        }
        _velocity = Vector3.forward * _speed;
    }

    private void Update()
    {
        _desiredLane = GetInput.GetLane(_desiredLane);
        transform.position = GetLane.GetPosition(_desiredLane, _laneDistance);
        _cc.center = _cc.center;
        _velocity = GetJump.Jump(_velocity);
        _cc.Move(_velocity * Time.deltaTime);
    }
}
