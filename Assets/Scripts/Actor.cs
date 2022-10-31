using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Actor : MonoBehaviour
{
    [SerializeField] protected int _maxMoveDistance;
    [SerializeField] protected int _maxActionPoints;
    [SerializeField] protected int _currActionPoints;
    protected bool _isTakingTurn;

    public bool IsTakingTurn
    {
        get { return _isTakingTurn; }
    }

    public int MaxMoveDistance
    {
        get { return _maxMoveDistance; }
    }

    public void Move(Vector2 destPos)
    {
        MoveAction moveAct = new MoveAction(destPos);
        moveAct.Execute(this);
    }

    public void TakeTurn()
    {
        PerformAction();

        if (_currActionPoints <= 0)
        {
            EndTurn();
        }
    }

    protected abstract void PerformAction();

    public virtual void QueueActions(ref ActionList actions)
    {
        actions.AddRangeAction(new List<Action>()
        {
        });
    }

    public void StartTurn()
    {
        RestoreActionPointsAtTurnStart();
        _isTakingTurn = true;
    }

    protected void RestoreActionPointsAtTurnStart()
    {
        if (_currActionPoints < _maxActionPoints)
        {
            _currActionPoints = _maxActionPoints;
        }
    }

    protected void EndTurn()
    {
        _isTakingTurn = false;
    }

    public void SpendActionPoints(int actionPointCost)
    {
        --_currActionPoints;
    }
}
