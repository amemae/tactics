using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionMenu : MonoBehaviour
{
    private List<ActionMenuButton> _menuButtons;
    private Vector2 _actionPosition;

    public void Start()
    {
        gameObject.SetActive(false);
        _menuButtons = new List<ActionMenuButton>();

        StoreMenuButtonReferences();
    }

    private void StoreMenuButtonReferences()
    {
        Transform transform = gameObject.transform;
        string currChildName = null;

        for (int childIndex = 0; childIndex < transform.childCount; ++childIndex)
        {
            currChildName = transform.GetChild(childIndex).name;
            _menuButtons.Add(GetActionMenuButtonWithName(currChildName));
        }
    }

    private ActionMenuButton GetActionMenuButtonWithName(string name)
    {
        GameObject ActionMenuGO = transform.Find(name).gameObject;
        return ActionMenuGO.GetComponent<ActionMenuButton>();
    }

    public void Display()
    {
        gameObject.SetActive(true);

        SetPositionToMousePosition();
        StoreActionPosition();

        DisplayAppropriateMenuOptions();
    }

    private void SetPositionToMousePosition()
    {
        transform.position = MouseManager.GetMousePosition();
    }

    private void StoreActionPosition()
    {
        Vector2 exactPosition = MouseManager.GetMousePosition();
        _actionPosition = GameManager.Instance.Grid.GetTileCenterPosition(exactPosition);
    }

    private void DisplayAppropriateMenuOptions()
    {
        foreach (ActionMenuButton button in _menuButtons)
        {
            if (IsButtonValidToDisplay(button))
            {
                button.Display();
            }
            else
            {
                button.Hide();
            }
        }
    }

    private bool IsButtonValidToDisplay(ActionMenuButton button)
    {
        return button.AmIValidToDisplay(_actionPosition);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool IsDisplayed()
    {
        return gameObject.activeInHierarchy;
    }

    public void TestButton()
    {
        Debug.Log("Button clicked");
    }
}
