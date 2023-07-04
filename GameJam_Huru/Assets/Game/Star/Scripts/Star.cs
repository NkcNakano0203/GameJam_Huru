using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UniRx;

public class Star : MonoBehaviour
{
    [SerializeField]
    int addScoreValue;
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotationSpeed;
    [SerializeField]
    StarMover starMover;
    [SerializeField]
    StarRotator starRotator;

    public int AddScoreValue => addScoreValue;

    private void Start()
    {
        starMover.MoveEnd.Subscribe(x => { Term(); });
    }

    public void Init(SplineContainer spline)
    {
        // ランダムでスプラインを入れる
        starMover.Init(moveSpeed, spline);
        starRotator.Init(rotationSpeed);
    }

    public void Term()
    {
        starMover.Term();
        starRotator.Term();
        gameObject.SetActive(false);
    }
}