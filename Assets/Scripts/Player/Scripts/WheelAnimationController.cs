using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimationController : MonoBehaviour
{
    private Animator _anim;
    private GameManager _gm;
    private CharacterController _cc;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        if (_anim == null)
        {
            Debug.Log("Animator is null.");
        }

        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (_gm == null)
        {
            Debug.Log("Game Manager is null.");
        }

        _cc = transform.parent.GetComponent<CharacterController>();
        if (_cc == null)
        {
            Debug.Log("Character Controller is null");
        }
    }

    private void Update()
    {
        if (_gm._isGameStarted)
        {
            _anim.SetBool("isGameStarted", true);
        }

        if (_cc.isGrounded)
        {
            _anim.SetBool("isGrounded", true);
        }
        else
        {
            _anim.SetBool("isGrounded", false);
        }
    }
}
