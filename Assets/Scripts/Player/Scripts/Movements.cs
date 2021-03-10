using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour, IGetLane, IGetJump
{
    [SerializeField]
    private float _jumpForce = 25f;
    [SerializeField]
    private float _gravity = 1f;
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
    public Vector3 GetPosition(int lane,float laneDistance)
    {
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (lane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (lane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        Vector3 newPosition = Vector3.Lerp(transform.position, targetPosition, 10 * Time.deltaTime);
        return newPosition;
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
}
