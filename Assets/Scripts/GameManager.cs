using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] private GridController _grid;

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

    public GridController Grid
    {
        get { return _grid; }
    }

    private void Awake()
    {
        _instance = this;
       
    }

    private void Start()
    {
        GameLoopManager.Instance.BeginGameLoop();
    }
}
