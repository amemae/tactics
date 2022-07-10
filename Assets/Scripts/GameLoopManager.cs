using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private static GameLoopManager _instance;

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
        Actor currActor = GameManager.Instance.InitiativeList.Current();

        while (currActor.IsTurnEnded() == false)
        {
            currActor.Act();
        }

        GameManager.Instance.InitiativeList.Advance();
    }
}
