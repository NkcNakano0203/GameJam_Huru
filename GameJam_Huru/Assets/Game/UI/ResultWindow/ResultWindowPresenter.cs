using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class ResultWindowPresenter : MonoBehaviour
{
    [SerializeField]
    ResultWindowView view;
    [SerializeField]
    ResultWindowModel model;

    private void Start()
    {
        model.ScoreSubject.Subscribe(x => { view.OnGoal(); });
        view.ButtonSubject.Subscribe(x => { model.OnClick(); });
    }
}