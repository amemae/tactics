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
    }

    private void EndTurn()
    {
        GameManager.Instance.InitiativeList.Advance();
    }
}
