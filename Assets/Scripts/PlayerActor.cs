using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : Actor
{
    protected override void PerformAction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Move(CalcMovePosition());
        }
    }

    private Vector2 CalcMovePosition()
    {
        Vector2 destPos = MouseManager.GetMousePosition();
        return GameManager.Instance.Grid.GetTileCenterPosition(destPos);
    }
}
