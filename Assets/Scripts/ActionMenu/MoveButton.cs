using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : ActionMenuButton
{
    protected override void OnClickAction()
    {
        _actingActor.Move(_actionPosition);
    }

    protected override bool AmIValidToDisplay()
    {
        if (!IsMovePosInRange())
        {
            return false;
        }

        if (IsMovePosCurrPos())
        {
            return false;
        }

        return true;
    }

    private bool IsMovePosInRange()
    {
        Vector2 currentTile = GameManager.Instance.Grid.GetTileCenterPosition(_actingActor.transform.position);

        float distance = Vector2.Distance(_actionPosition, currentTile);

        if (distance > _actingActor.MaxMoveDistance)
        {
            return false;
        }

        return true;
    }

    private bool IsMovePosCurrPos()
    {
        Vector2 currentTile = GameManager.Instance.Grid.GetTileCenterPosition(_actingActor.transform.position);

        if (_actionPosition == currentTile)
        {
            return true;
        }

        return false;
    }
}
