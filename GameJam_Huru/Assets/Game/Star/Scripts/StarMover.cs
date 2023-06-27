using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using static UnityEngine.Rendering.DebugUI;

public class StarMover : MonoBehaviour
{
    [SerializeField]
    SplineContainer container;

    [SerializeField]
    Rigidbody rb;
    float moveSpeed = 0;
    float t;

    bool isCatched = false;

    void Update()
    {
        if (isCatched) return;
        if (t > 1) return;
        float time = container.CalculateLength() / moveSpeed;
        t += Time.deltaTime / time;
        rb.MovePosition(container.EvaluatePosition(t));
    }

    public void Init(float value, SplineContainer spline)
    {
        moveSpeed = value;
        container = spline;
    }

    public void Catched() => isCatched = true;
}