using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Actor : MonoBehaviour
{
    public void Move(Vector2 destPos)
    {
        MoveAction moveAct = new MoveAction(destPos);
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

    public virtual void QueueActions(ref ActionList actions)
    {
        actions.AddRangeAction(new List<Action>()
        {
        });
    }

    private bool IsTurnEnded()
    {
        return false;
    }
}
