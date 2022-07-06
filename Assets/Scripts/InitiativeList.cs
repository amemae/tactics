using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiativeList : MonoBehaviour
{
    private CircularList<Actor> _list;

    private void Start()
    {
        _list = new CircularList<Actor>();
    }

    public void Advance()
    {
        _list.AdvanceList();
    }

    public void Recede()
    {
        _list.RecedeList();
    }

    public void Insert(Actor actor)
    {
        _list.Insert(actor);
    }

    public void Remove(Actor actor)
    {
        _list.Remove(actor);
    }

    public Actor Current()
    {
        return _list.Peek();
    }
}
