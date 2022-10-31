using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionCommand
{
    protected Actor _actor;

    protected abstract int GetActionPointCost();

    public void Execute(Actor actor)
    {
        _actor = actor;
        _actor.SpendActionPoints(GetActionPointCost());

        Execute();
    }

    protected abstract void Execute();
}
