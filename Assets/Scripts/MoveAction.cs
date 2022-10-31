using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : ActionCommand
{
    Vector2 _destPost;

    protected override int GetActionPointCost()
    {
        return 1;
    }

    public MoveAction(Vector2 destPos)
    {
        _destPost = destPos;
    }

    protected override void Execute()
    {
        _actor.transform.position = _destPost;
    }
}
