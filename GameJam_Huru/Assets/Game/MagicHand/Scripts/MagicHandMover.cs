using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using Cysharp.Threading.Tasks;

namespace MagicHand
{
    public class MagicHandMover : MonoBehaviour
    {
        [SerializeField]
        GameObject inputHandler;
        [SerializeField]
        StarCatcher starCatcher;
        [SerializeField]
        Rigidbody rb;
        [SerializeField]
        float moveValue;

        IInputHandler input;
        Tweener tweener;
        Vector3 defaultPos;
        bool isMoving = false;

        private void Start()
        {
            defaultPos = transform.position;
            input = inputHandler.GetComponent<IInputHandler>();
            input.Push.Subscribe(x =>
            {
                MoveUp();
            });
            rb = GetComponent<Rigidbody>();
            starCatcher.CatchProperty.Subscribe(x =>
            {
                Stop();
                Debug.Log("A");
            });
        }

        private void Stop()
        {
            tweener.Kill();
            MoveDown();
        }

        private void MoveUp()
        {
            if (isMoving) return;
            isMoving = true;
            starCatcher.SetActive(true);
            tweener = rb.DOMoveY(moveValue, 0.5f)
                .SetEase(Ease.InSine)
                .SetRelative(true)
                .SetLink(gameObject)
                .OnComplete(() => { MoveDown(); });
        }

        private async UniTask MoveDown()
        {
            starCatcher.SetActive(false);
            await rb.DOMoveY(defaultPos.y - 3f, 0.5f)
                .SetEase(Ease.Linear)
                .SetLink(gameObject)
                .ToUniTask();

            rb.DOMoveY(defaultPos.y, 0.5f)
                .SetEase(Ease.OutSine)
                .SetLink(gameObject)
                .OnComplete(() => { isMoving = false; })
                .ToUniTask().Forget();
        }
    }
}