using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : ActionCommand
{
    Vector2 _destPost;
    public MoveAction(Vector2 destPos)
    {
        _destPost = destPos;
    }

    public override void Execute(Actor actor)
    {
        actor.transform.position = _destPost;
    }
}
