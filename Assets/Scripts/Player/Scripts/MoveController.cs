using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private float _laneDistance = 4f;
    public float _speed = 5f;
    private CharacterController _cc;
    private IGetInput GetInput;
    private IGetLane GetLane;
    private int _desiredLane = 1; //0: left, 1: middle, 2: right
    private Vector3 _velocity;

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

    }

    private void Update()
    {
        _desiredLane = GetInput.GetLane(_desiredLane);
        transform.position = GetLane.GetLane(_desiredLane, _laneDistance);
        _cc.center = _cc.center;
    }
    void FixedUpdate()
    {
        _velocity = Vector3.forward * _speed;
        _cc.Move(_velocity * Time.fixedDeltaTime);
    }
}
