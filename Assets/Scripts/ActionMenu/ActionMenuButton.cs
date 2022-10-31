using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ActionMenuButton : MonoBehaviour
{
    protected Actor _actingActor;
    protected Button _button;
    protected Vector2 _actionPosition;

    protected virtual void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    protected void OnClick()
    {
        GameManager.Instance.ActionMenu.Hide();

        OnClickAction();
    }

    protected abstract void OnClickAction();

    public bool AmIValidToDisplay(Vector2 actionPosition)
    {
        _actionPosition = actionPosition;
        _actingActor = GameLoopManager.Instance.CurrentActor();

        return AmIValidToDisplay();
    }

    protected abstract bool AmIValidToDisplay();

    public void Display()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}