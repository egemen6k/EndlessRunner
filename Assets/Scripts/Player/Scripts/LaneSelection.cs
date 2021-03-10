using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSelection : MonoBehaviour, IGetLane
{
    public Vector3 GetLane(int lane,float laneDistance)
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
}
