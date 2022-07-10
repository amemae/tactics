using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : Actor
{
    public override void Act()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnActionKey();
        }
    }
}
