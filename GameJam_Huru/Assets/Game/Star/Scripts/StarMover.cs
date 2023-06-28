using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class StarMover : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    SplineContainer container;
    float moveSpeed = 0;
    float t;

    bool isCatched = true;

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
        isCatched = false;
    }

    public void Catched() => isCatched = true;
}