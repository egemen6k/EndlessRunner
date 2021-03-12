using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour,IGetHorizontal,IGetVertical
{
    [SerializeField]
    private float _jumpForce = 25f;
    [SerializeField]
    private float _gravity = 0.4f;
    private float _yVelocity;
    private Vector3 _firstPressPos,_swipeDirection;
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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _firstPressPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    break;

                case TouchPhase.Ended:
                    Vector3 _releasePos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                    _swipeDirection = _releasePos - _firstPressPos;
                    _swipeDirection.Normalize();

                    if (_swipeDirection.x < 0 && _swipeDirection.y > -0.5f && _swipeDirection.y < 0.5f)
                    {
                        lane--;
                        if (lane == -1)
                        {
                            lane = 0;
                        }
                    }
                    if (_swipeDirection.x > 0 && _swipeDirection.y > -0.5f && _swipeDirection.y < 0.5f)
                    {
                        lane++;
                        if (lane == 3)
                        {
                            lane = 2;
                        }
                    }
                    break;
            }
        }
        return lane;
    }

    public Vector3 Jump(Vector3 velocity)
    {
        if (_cc.isGrounded)
        {
            if (_swipeDirection.y > 0 && _swipeDirection.x > -0.5f && _swipeDirection.x < 0.5f)
            {
                _yVelocity = _jumpForce;
                _swipeDirection = Vector3.zero;
            }
        }
        else
        {
            _yVelocity -= _gravity;
        }
        velocity.y = _yVelocity;
        return velocity;
    }

    public void Slide()
    {
        if (_swipeDirection.y < 0 && _swipeDirection.x > -0.5f && _swipeDirection.x < 0.5f)
        {
            Debug.Log("DOWN");
        }
    }
}
