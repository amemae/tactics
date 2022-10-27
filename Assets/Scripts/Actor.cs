using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Actor : MonoBehaviour
{
    [SerializeField] protected int _maxMoveDistance;
    [SerializeField] protected int _maxActionPoints;
    [SerializeField] protected int _currActionPoints;
    public void Move(Vector2 destPos)
    {
        MoveAction moveAct = new MoveAction(destPos);
        moveAct.Execute(this);
    }

    public IEnumerator TakeTurn()
    {
        StartTurn();

        if (_currActionPoints <= _maxActionPoints)
        {

        }

        while (_currActionPoints > 0)
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

    private void StartTurn()
    {
        RestoreActionPointsAtTurnStart();
    }

    protected void RestoreActionPointsAtTurnStart()
    {
        if (_currActionPoints < _maxActionPoints)
        {
            _currActionPoints = _maxActionPoints;
        }
    }
}
