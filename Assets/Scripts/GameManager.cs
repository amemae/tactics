using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    [SerializeField] private GridController _grid;
    [SerializeField] private ActionMenu _actionMenu;

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

    public ActionMenu ActionMenu
    {
        get { return _actionMenu; }
    }

    private void Awake()
    {
        _instance = this;
    }
}
