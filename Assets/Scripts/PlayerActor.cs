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

        if (!IsMovePosInRange(destPos))
        {
            return GameManager.Instance.Grid.GetTileCenterPosition(transform.position);
        }
        
        return GameManager.Instance.Grid.GetTileCenterPosition(destPos);
    }

    private bool IsMovePosInRange(Vector2 destPos)
    {
        Vector2 destTile = GameManager.Instance.Grid.GetTileCenterPosition(destPos);
        Vector2 currentTile = GameManager.Instance.Grid.GetTileCenterPosition(transform.position);

        float distance = Vector2.Distance(destTile, currentTile);

        if (distance > _maxMoveDistance)
            return false;

        return true;
    }
}
