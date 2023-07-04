using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class ResultWindowView : MonoBehaviour
{
    [SerializeField]
    RectTransform rectTransform;
    [SerializeField]
    Button titleButton;

    private Subject<Unit> buttonSubject = new Subject<Unit>();
    public IObservable<Unit> ButtonSubject => buttonSubject;

    private void Start()
    {
        titleButton.OnClickAsObservable().Subscribe(buttonSubject.OnNext);
    }
    public void OnGoal()
    {
        rectTransform.DOLocalMoveY(0, 0.5f)
            .SetEase(Ease.OutSine)
            .SetLink(gameObject);
    }
}