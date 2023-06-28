using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class StarFactory : MonoBehaviour
{
    [SerializeField]
    Star[] star;
    [SerializeField]
    SplineContainer[] splines;
    float t;

    public bool plaing = false;

    void Update()
    {
        if (!plaing) return;
        t += Time.deltaTime;
        if (t <= 2) return;
        for (int i = 0; i < star.Length; i++)
        {
            if (!star[i].gameObject.activeSelf) continue;
            star[i].gameObject.SetActive(true);
            star[i].Init(splines[Random.Range(0, splines.Length)]);
        }
        t = 0;
    }
}