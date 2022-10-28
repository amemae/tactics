using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private static GameLoopManager _instance;
    private InitiativeList _initiativeList;
    private Actor _currActor;
    private bool _turnActive = false;

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

        /******************* Test Code ***********************/
        _initiativeList = new InitiativeList();

        Actor actor = Instantiate(_TESTACTOR, new Vector2(.5f, .5f), Quaternion.identity);
        _initiativeList.Insert(actor);
    }

    public void BeginGameLoop()
    {
        StartCoroutine(ExecuteTurn());
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
        _currActor = _initiativeList.Current();
        _currActor.StartTurn();
    }

    

    private void EndTurn()
    {
        _initiativeList.Advance();
    }
}
