using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActionList : IEnumerable
{
    public List<Action> _actions;
    private int _currActionIndex;

    public ActionList()
    {
        _actions = new List<Action>();
        _currActionIndex = 0;
    }

    public void AddAction(Action action)
    {
        _actions.Add(action);
    }

    public void AddRangeAction(List<Action> action)
    {
        _actions.AddRange(action);
    }

    public void ExecuteNextAction()
    {
        _actions[_currActionIndex].Invoke();
        ++_currActionIndex;

        if (_currActionIndex >= _actions.Count)
        {
            _currActionIndex = 0;
        }
    }

    public IEnumerator GetEnumerator()
    {
        return _actions.GetEnumerator();
    }
}
