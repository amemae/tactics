using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActor : Actor
{
    protected override void PerformAction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 movePos;
            try
            {
                movePos = CalcMovePosition();
                Move(CalcMovePosition());
                --_currActionPoints;
            }
            catch
            {
                //If the position isn't valid then do nothing
            }
        }
    }

    private Vector2 CalcMovePosition()
    {
        Vector2 destPos = MouseManager.GetMousePosition();

        ThrowRelevantMoveException(destPos);
        
        return GameManager.Instance.Grid.GetTileCenterPosition(destPos);
    }


    private void ThrowRelevantMoveException(Vector2 destPos)
    {
        if (IsMovePosInRange(destPos) is false)
        {
            throw new System.Exception("Position not in range");
        }

        if (IsMovePosCurrPos(destPos) is true)
        {
            throw new System.Exception("Position is current position");
        }
    }


    private bool IsMovePosInRange(Vector2 destPos)
    {
        Vector2 destTile = GameManager.Instance.Grid.GetTileCenterPosition(destPos);
        Vector2 currentTile = GameManager.Instance.Grid.GetTileCenterPosition(transform.position);

        float distance = Vector2.Distance(destTile, currentTile);

        if (distance > _maxMoveDistance)
        {
            return false;
        }

        return true;
    }

    private bool IsMovePosCurrPos(Vector2 destPos)
    {
        Vector2 destTile = GameManager.Instance.Grid.GetTileCenterPosition(destPos);
        Vector2 currentTile = GameManager.Instance.Grid.GetTileCenterPosition(transform.position);

        if (destTile == currentTile)
        {
            return true;
        }

        return false;
    }
}
