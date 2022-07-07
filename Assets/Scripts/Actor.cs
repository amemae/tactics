using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    MoveAction _moveAction;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
