using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace MagicHand
{
    /// <summary>
    /// マジックハンドの星捕まえ判定クラス
    /// </summary>
    public class StarCatcher : MonoBehaviour
    {
        [SerializeField]
        Transform handTrans;

        bool isActive = false;

        private ReactiveProperty<int> catchProperty = new ReactiveProperty<int>(0);
        public IObservable<int> CatchProperty => catchProperty.SkipLatestValueOnSubscribe();

        void Start()
        {

        }

        public void SetActive(bool active)
        {
            isActive = active;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isActive) return;
            // スターを識別してスコア加算イベントを発行する
            if (!other.TryGetComponent(out Star star)) return;
            star.Catched();
            star.transform.SetParent(handTrans);
            Destroy(star.gameObject, 1);
            catchProperty.Value += star.AddScoreValue;
            isActive = false;
        }
    }
}