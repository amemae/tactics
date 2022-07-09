using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorState
{
    public virtual void OnActionKey()
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
    public override void OnActionKey()
    {

    }
}

public class CannotActActorState : ActorState
{
    public override void OnActionKey()
    {

    }
}

public class DeadActorState : ActorState
{}