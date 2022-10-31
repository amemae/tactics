using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularList<T>
{
    private List<T> _list;
    private int? _headIndex;
    
    public CircularList()
    {
        _list = new List<T>();
        _headIndex = null;
    }

    private int CalcInsertionIndex()
    {
        if (_headIndex.HasValue is false)
        {
            return 0;
        }

        if (_headIndex == 0)
        {
            return _list.Count;
        }

        return _headIndex.Value - 1;
    }

    public void Insert(T data)
    {
        if (_list.Contains(data))
        {
            throw new System.InvalidOperationException("Cannot insert duplicate data into list");
        }

        int insertionIndex = CalcInsertionIndex();
        if (insertionIndex == 0)
        {
            _headIndex = 0;
        }
        _list.Insert(insertionIndex, data);
    }

    public void Remove(T data)
    {
        int dataIndex = _list.IndexOf(data);

        if (dataIndex == -1)
        {
            throw new System.InvalidOperationException("Data not found for removal");
        }

        if (_headIndex > dataIndex)
        {
            --_headIndex;
        }

        _list.RemoveAt(dataIndex);

        if (_list.Count == 0)
        {
            _headIndex = null;
        }
    }

    public void AdvanceList()
    {
        if (_headIndex.HasValue is false)
        {
            throw new System.InvalidOperationException("Cannot advance empty list");
        }

        ++_headIndex;

        if (_headIndex == _list.Count)
        {
            _headIndex = 0;
        }
    }

    public void RecedeList()
    {
        if (_headIndex.HasValue is false)
        {
            throw new System.InvalidOperationException("Cannot recede empty list");
        }

        --_headIndex;

        if (_headIndex == -1)
        {
            _headIndex = _list.Count - 1;
        }
    }

    public T Peek()
    {
        if (_headIndex.HasValue is false)
        {
            throw new System.InvalidOperationException("Cannot peek empty list");
        }

        return _list[_headIndex.Value];
    }
}
