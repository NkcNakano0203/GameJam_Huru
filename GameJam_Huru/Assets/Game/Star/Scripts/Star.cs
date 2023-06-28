using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

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

    SplineContainer spline;

    public int AddScoreValue => addScoreValue;

    public void Init(SplineContainer spline)
    {
        // ランダムでスプラインを入れる
        starMover.Init(moveSpeed, spline);
        starRotator.Init(rotationSpeed);
    }

    public void Catched()
    {
        starMover.Catched();
        starRotator.Catched();
    }
}