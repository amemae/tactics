using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class MouseManager
{
    public static Vector2 GetMousePosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public static Vector2 GetCenteredMousePosition()
    {
        Vector2 position = GetMousePosition();

        position.x = ((int)position.x) + .5f;
        position.y = ((int)position.y) + .5f;

        return position;
    }
}
