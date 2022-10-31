using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : Actor
{
    protected override bool IsTryingToAct()
    {
        if (Input.GetMouseButtonDown(1))
        {
            return true;
        }
        return false;
    }
}
