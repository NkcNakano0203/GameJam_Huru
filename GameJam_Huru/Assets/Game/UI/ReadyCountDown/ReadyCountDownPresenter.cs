using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ReadyCountDownPresenter : MonoBehaviour
{
    [SerializeField]
    ReadyCountDownView view;
    [SerializeField]
    GameManager model;

    private void Start()
    {
        model.ReadyCountDownSubject.Subscribe(view.SetNumber);
    }
}