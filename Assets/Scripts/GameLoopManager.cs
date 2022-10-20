using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private static GameLoopManager _instance;
    private Actor _currActor;

    public static GameLoopManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameLoopManager");
                go.AddComponent<GameLoopManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void ExecuteTurn()
    {
        SetupTurn();
        StartCoroutine(_currActor.Act());           
        EndTurn();
    }

    private void SetupTurn()
    {
        _currActor = GameManager.Instance.InitiativeList.Current();
        _currActor.ChangeState(new AwaitCommandActorState(_currActor));
    }

    private void EndTurn()
    {
        _currActor.ChangeState(new EndedTurnActorState(_currActor));
        GameManager.Instance.InitiativeList.Advance();
    }
}
