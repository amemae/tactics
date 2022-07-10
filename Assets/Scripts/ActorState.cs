using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorState
{
    protected Actor _actor;

    public ActorState(Actor actor)
    {
        _actor = actor;
    }

    public virtual void OnAction()
    {
        ThrowGeneralUnimplementedException();
    }

    private void ThrowGeneralUnimplementedException()
    {
        throw new System.NotImplementedException("Method is not implemented in the current state");
    }
}

public class AwaitCommandActorState : ActorState
{
    public AwaitCommandActorState(Actor actor) : base(actor)
    { }

    public override void OnAction()
    {
        Vector2 mousePos = MouseManager.GetCenteredMousePosition();
        _actor.Move(mousePos);
    }
}

public class CannotActActorState : ActorState
{
    public CannotActActorState(Actor actor) : base(actor)
    { }

    public override void OnAction()
    {

    }
}

public class DeadActorState : ActorState
{
    public DeadActorState(Actor actor) : base(actor)
    { }
}

public class EndedTurnActorState : ActorState
{
    public EndedTurnActorState(Actor actor) : base(actor)
    { }
}