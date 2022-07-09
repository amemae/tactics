using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Actor : MonoBehaviour
{
    ActorState _actorState;
    MoveAction _moveAction;

    public void Start()
    {
        _actorState = new AwaitCommandActorState();    
    }

    private Vector2 CalcNextPosition()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        _moveAction = new MoveAction(CalcNextPosition());
        _moveAction.Execute(this);
    }

    public void Act()
    {
        ActionList actions = new ActionList();
        QueueActions(ref actions);
        foreach (Action action in actions)
        {
            action.Invoke();
        }
    }

    public virtual void QueueActions(ref ActionList actions)
    {
        actions.AddRangeAction(new List<Action>()
        {
            Move,
        });
    }
}
