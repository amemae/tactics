using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private InitiativeList _initiativeList;
    [SerializeField] private GridController _grid;

    public Actor _TESTACTOR;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public InitiativeList InitiativeList
    {
        get { return _initiativeList; }
    }

    public GridController Grid
    {
        get { return _grid; }
    }

    private void Awake()
    {
        _instance = this;
        _initiativeList = new InitiativeList();

        Actor actor = Instantiate(_TESTACTOR);
        _initiativeList.Insert(actor);
    }

    private void Update()
    {
        GameLoopManager.Instance.ExecuteTurn();
    }
}
