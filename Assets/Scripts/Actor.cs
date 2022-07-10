using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Actor : MonoBehaviour
{
    ActorState _actorState;

    public void Start()
    {
        _actorState = new AwaitCommandActorState(this);    
    }

    public void Move(Vector2 mousePos)
    {
        MoveAction moveAct = new MoveAction(mousePos);
        moveAct.Execute(this);
    }

    public abstract void Act();

    protected void OnActionKey()
    {
        _actorState.OnAction();
    }

    public virtual void QueueActions(ref ActionList actions)
    {
        actions.AddRangeAction(new List<Action>()
        {
            
        });
    }

    public bool IsTurnEnded()
    {
        return _actorState is EndedTurnActorState;
    }
}
