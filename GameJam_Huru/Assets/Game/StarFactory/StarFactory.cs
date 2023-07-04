using MagicHand;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using UniRx;

public class StarFactory : MonoBehaviour
{
    [SerializeField]
    Star[] stars;
    [SerializeField]
    SplineContainer[] splines;
    [SerializeField]
    float spawnSpan = 2;
    [SerializeField]
    StarCatcher starCatcher;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    Vector3 poolPos;

    float t = 0;

    private void Start()
    {
        starCatcher.StarSubject.Subscribe(Disable);
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (gameManager.GetCurrentGameState == GameManager.GameState.Finish) return;
        t += Time.deltaTime;
        if (t < spawnSpan) return;
        t = 0;
        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i].gameObject.activeSelf) continue;
            stars[i].gameObject.SetActive(true);
            stars[i].Init(splines[Random.Range(0, splines.Length)]);
            return;
        }
    }

    void Disable(Star star)
    {
        star.Term();
        star.transform.position = poolPos;
    }
}