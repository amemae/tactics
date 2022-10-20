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

    public IEnumerator Act()
    {
        while (IsTurnEnded() == false)
        {
            PerformAction();
            yield return null;
        }
    }

    protected abstract void PerformAction();

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

    private bool IsTurnEnded()
    {
        return _actorState is EndedTurnActorState;
    }

    public void ChangeState(ActorState newState)
    {
        _actorState.ChangeState(newState);
    }
}
