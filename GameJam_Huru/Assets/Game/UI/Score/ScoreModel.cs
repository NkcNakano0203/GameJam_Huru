using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using MagicHand;

public class ScoreModel : MonoBehaviour
{
    [SerializeField]
    StarCatcher starCatcher;

    private ReactiveProperty<int> scoreProperty = new ReactiveProperty<int>(0);
    public IReactiveProperty<int> ScoreProperty => scoreProperty;

    void Start()
    {
        starCatcher.CatchProperty.Subscribe(x => { scoreProperty.Value = x; });
    }
}