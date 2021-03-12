using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAnimationController : MonoBehaviour
{
    private Animator _anim;
    private GameManager _gm;
    private CharacterController _cc;
    private IGetVertical VerticalMove;
    private bool _isSliding;

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

        VerticalMove = transform.parent.GetComponent<IGetVertical>();
        if (VerticalMove == null)
        {
            Debug.Log("Vertical Input is null");
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

        if (VerticalMove.Slide() && !_isSliding)
        {
            StartCoroutine(Slide());
        }
    }

    IEnumerator Slide()
    {
        _isSliding = true;
        _anim.SetBool("isSliding", true);
        _cc.center = new Vector3(0f, -0.5f, 0f);
        _cc.height = 1f;
        yield return new WaitForSeconds(1f);
        _anim.SetBool("isSliding", false);
        _cc.center = new Vector3(0f, 0f, 0f);
        _cc.height = 2f;
        _isSliding = false;
    }
}
