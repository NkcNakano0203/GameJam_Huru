using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UniRx;
using System;
using static UnityEngine.Rendering.DebugUI;
using System.Numerics;

public class StarMover : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    TrailRenderer trailRenderer;

    private Subject<bool> moveEndSubject = new();
    public IObservable<bool> MoveEnd => moveEndSubject;

    SplineContainer container;
    float moveSpeed = 0;
    float t = 0;

    bool isActive = false;

    void Update()
    {
        if (!isActive) return;
        if (t > 1)
        {
            Term();
            moveEndSubject.OnNext(true);
            return;
        }
        float time = container.CalculateLength() / moveSpeed;
        t += Time.deltaTime / time;
        rb.MovePosition(container.EvaluatePosition(t));
    }

    public void Init(float value, SplineContainer spline)
    {
        moveSpeed = value;
        container = spline;
        isActive = true;
        trailRenderer.enabled = true;
    }

    public void Term()
    {
        isActive = false;
        moveSpeed = 0;
        container = null;
        trailRenderer.enabled = false;
        t = 0;
    }
}