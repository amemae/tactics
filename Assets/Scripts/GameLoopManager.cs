using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private static GameLoopManager _instance;
    private InitiativeList _initiativeList;
    private Actor _currActor;
    private bool _loopIsReadyToAdvance;

    public Actor _TESTACTOR;

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
        _loopIsReadyToAdvance = true;

        /******************* Test Code ***********************/
        _initiativeList = new InitiativeList();

        Actor actor = Instantiate(_TESTACTOR, new Vector2(.5f, .5f), Quaternion.identity);
        _initiativeList.Insert(actor);
    }

    private void Update()
    {
        AdvanceGameLoop();
    }

    public void AdvanceGameLoop()
    {
        if (_loopIsReadyToAdvance)
        {
            StartCoroutine(ExecuteTurn());
        }
    }

    public IEnumerator ExecuteTurn()
    {
        SetupTurn();

        while (_currActor.IsTakingTurn)
        {
            _currActor.TakeTurn();
            yield return null;
        }

        EndTurn();
    }

    private void SetupTurn()
    {
        _loopIsReadyToAdvance = false;
        _currActor = _initiativeList.Current();
        _currActor.StartTurn();
    }

    

    private void EndTurn()
    {
        _initiativeList.Advance();
        _loopIsReadyToAdvance = true;
    }
}
