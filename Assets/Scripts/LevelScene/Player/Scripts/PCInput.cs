using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput : MonoBehaviour, IGetHorizontal,IGetVertical
{
    [SerializeField]
    private float _jumpForce = 10f;
    [SerializeField]
    private float _gravity = 0.17f;
    private float _yVelocity;
    private CharacterController _cc;

    private void Start()
    {
        _cc = GetComponent<CharacterController>();
        if (_cc == null)
        {
            Debug.LogError("Character Controller is null.");
        }
    }
    public int GetLane(int lane)
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lane++;
            if (lane == 3)
            {
                lane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lane--;
            if (lane == -1)
            {
                lane = 0;
            }
        }
        return lane;
    }

    public Vector3 Jump(Vector3 velocity)
    {
        if (_cc.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _yVelocity = _jumpForce;
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        return velocity;
    }

    public bool Slide()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return true; 
        }
        else
        {
            return false;
        }
    }
}
