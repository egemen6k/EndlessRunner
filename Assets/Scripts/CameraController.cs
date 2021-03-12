using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - _target.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + _target.position.z);
        transform.position = Vector3.Lerp(transform.position,newPosition, 10f * Time.deltaTime);
    }
}
