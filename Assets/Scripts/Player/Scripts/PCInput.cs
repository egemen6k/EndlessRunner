using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInput : MonoBehaviour, IGetInput
{
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
}
