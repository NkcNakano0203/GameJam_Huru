using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using System;

public class ResultWindowModel : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    private Subject<Unit> scoreSubject = new Subject<Unit>();
    public IObservable<Unit> ScoreSubject => scoreSubject;

    void Start()
    {
        gameManager.GameEndSubject.Subscribe(_ =>
        {
            scoreSubject.OnNext(default);
        });
    }
    public void OnClick()
    {
        SceneManager.LoadSceneAsync("TitleScene");
    }
}