using UniRx;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour, IInputHandler
{
    [SerializeField]
    PlayerInput playerInput;

    private ReactiveProperty<Vector2> moveProperty = new();
    public IReadOnlyReactiveProperty<Vector2> Move => moveProperty;

    private Subject<bool> pushSubject = new();
    public IObservable<bool> Push => pushSubject;

    private Subject<Unit> escapeSubject = new();
    public IObservable<Unit> Escape => escapeSubject;

    private void Start()
    {
        playerInput.actions["Move"].performed += OnMoved;
        playerInput.actions["Push"].started += OnPushed;
        playerInput.actions["ESC"].performed += OnEscaped;
    }

    private void OnDestroy()
    {
        playerInput.actions.Disable();
    }

    private void OnMoved(InputAction.CallbackContext callback)
    {
        Vector2 inputVec = callback.ReadValue<Vector2>();
        moveProperty.Value = inputVec;
    }

    private void OnPushed(InputAction.CallbackContext callback)
    {
        bool isPush = callback.ReadValueAsButton();
        pushSubject.OnNext(isPush);
    }

    private void OnEscaped(InputAction.CallbackContext callback)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}