using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ReadyCountDownView : MonoBehaviour
{
    [SerializeField]
    GameObject countDownObj;
    [SerializeField]
    Text text;

    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = text.GetComponent<RectTransform>();
    }
    public void SetNumber(int value)
    {
        rectTransform.localScale = Vector3.one;
        text.text = value.ToString();
        rectTransform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 0.9f)
            .OnComplete(() =>
            {
                Debug.Log(value);
                if (value != 1) return;
                countDownObj.SetActive(false);
            });
    }
}