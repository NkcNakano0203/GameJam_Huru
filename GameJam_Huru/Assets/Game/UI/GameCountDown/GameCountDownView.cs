using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCountDownView : MonoBehaviour
{
    [SerializeField]
    Text text;

    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = text.GetComponent<RectTransform>();
    }
    public void SetNumber(int value)
    {
        rectTransform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        text.text = value.ToString();
        rectTransform.DOScale(Vector3.one, 0.9f);
    }
}