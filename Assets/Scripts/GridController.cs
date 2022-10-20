using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    private Grid _grid;
    void Start()
    {
        _grid = gameObject.GetComponent<Grid>();
    }

    public Vector2 GetTileCenterPosition(Vector2 position)
    {
        position = (Vector2Int)_grid.WorldToCell(position);
        return _grid.GetCellCenterWorld(Vector3Int.RoundToInt(position));
    }
}
