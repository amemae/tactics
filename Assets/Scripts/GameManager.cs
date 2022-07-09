using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private InitiativeList _initiativeList;

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

    private void Awake()
    {
        _instance = this;
        _initiativeList = new InitiativeList();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log(MouseManager.GetMousePosition());
        }
    }
}
