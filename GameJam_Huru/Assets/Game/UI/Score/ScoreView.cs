using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    [SerializeField]
    Text text;

    int currentScore = 0;
    public void SetScore(int totalScoreValue)
    {
        text.DOCounter(currentScore, totalScoreValue, 0.2f);
        currentScore = totalScoreValue;
    }
}