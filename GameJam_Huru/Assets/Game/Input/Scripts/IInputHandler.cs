using System;
using UniRx;
using UnityEngine;

public interface IInputHandler
{
    public IReadOnlyReactiveProperty<float> Move { get; }
    public IObservable<bool> Push { get; }
    public IObservable<Unit> Escape { get; }
}