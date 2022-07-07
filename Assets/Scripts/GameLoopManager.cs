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
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameLoopManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public void ExecuteTurn()
    {
        Actor currActor = GameManager.Instance.InitiativeList.Current();
        currActor.Act();
        GameManager.Instance.InitiativeList.Advance();
    }
}
