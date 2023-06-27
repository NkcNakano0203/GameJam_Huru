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
    [SerializeField]
    SplineContainer[] splines;

    public int AddScoreValue => addScoreValue;

    private void Start()
    {
        Init();
    }
    public void Init()
    {
        // ランダムでスプラインを入れる
        starMover.Init(moveSpeed, splines[0]);
        starRotator.Init(rotationSpeed);
    }

    public void Catched()
    {
        starMover.Catched();
        starRotator.Catched();
    }
}