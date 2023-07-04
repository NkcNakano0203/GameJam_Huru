using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;

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
        [SerializeField]
        float horizontalSpeed;
        [SerializeField]
        float brakeValue;

        IInputHandler input;
        Tweener tweener;
        Vector3 defaultPos;
        bool isMoving = false;
        float currentInputX;

        private void Start()
        {
            defaultPos = transform.position;
            input = inputHandler.GetComponent<IInputHandler>();
            rb = GetComponent<Rigidbody>();

            input.Move.Subscribe(Move);
            input.Push.Subscribe(PushUp);
            starCatcher.CatchProperty.Subscribe(Stop);
        }

        private void FixedUpdate()
        {
            if (currentInputX == 0)
            { rb.velocity = Brake(brakeValue); }
        }

        private void Move(float inputX)
        {
            currentInputX = inputX;
            if (inputX == 0) return;
            rb.velocity = new Vector3(inputX * horizontalSpeed, 0, 0);
        }

        private Vector3 Brake(float brakeValue)
        {
            if (rb.velocity.x < brakeValue)
            {
                // ˆê’è‘¬“xˆÈ‰º‚É‚È‚Á‚½‚çŽ~‚ß‚é
                return Vector3.zero;
            }
            else
            {
                // ‚ä‚Á‚­‚èŒ¸‘¬‚·‚é
                return new Vector3(rb.velocity.x - (rb.velocity.x >= 0 ? brakeValue : -brakeValue), 0, 0);
            }
        }

        private void Stop(int i)
        {
            tweener.Kill();
            PullDown();
        }

        private void PushUp(bool x)
        {
            if (isMoving) return;
            isMoving = true;
            starCatcher.SetActive(true);
            tweener = rb.DOMoveY(moveValue, 0.4f)
                .SetEase(Ease.InSine)
                .SetRelative(true)
                .SetLink(gameObject)
                .OnComplete(() => { PullDown(); });
        }

        private void PullDown()
        {
            starCatcher.SetActive(false);
            rb.DOMoveY(defaultPos.y, 0.7f)
               .SetEase(Ease.OutBack)
               .SetLink(gameObject)
               .OnComplete(() => { isMoving = false; });
        }
    }
}