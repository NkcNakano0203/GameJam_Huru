using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ScorePresenter : MonoBehaviour
{
    [SerializeField]
    ScoreModel model;
    [SerializeField]
    ScoreView view;

    private void Start()
    {
        model.ScoreProperty.Subscribe(view.SetScore);
    }
}