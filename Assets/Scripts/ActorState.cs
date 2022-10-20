using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorState
{
    protected Actor _actor;
    protected ActorState _state;

    public ActorState(Actor actor)
    {
        _actor = actor;
        _state = this;
    }

    public virtual void ChangeState(ActorState newState)
    {
        _state = newState;
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
    {
        _state = this;
    }

    public override void OnAction()
    {
        Vector2 destPos = MouseManager.GetMousePosition();
        Vector2 destGridTile = GameManager.Instance.Grid.GetTileCenterPosition(destPos);
        _actor.Move(destGridTile);
    }
}

public class CannotActActorState : ActorState
{
    public CannotActActorState(Actor actor) : base(actor)
    {
        _state = this;
    }

    public override void OnAction()
    {

    }
}

public class DeadActorState : ActorState
{
    public DeadActorState(Actor actor) : base(actor)
    {
        _state = this;
    }
}

public class EndedTurnActorState : ActorState
{
    public EndedTurnActorState(Actor actor) : base(actor)
    {
        _state = this;
    }
}