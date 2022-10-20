using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : Actor
{
    protected override void PerformAction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnActionKey();
        }
    }
}
