using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameCountDownPresenter : MonoBehaviour
{
    [SerializeField]
    GameCountDownView view;
    [SerializeField]
    GameManager model;

    private void Start()
    {
        model.GameCountDownSubject.Subscribe(view.SetNumber);
    }
}
