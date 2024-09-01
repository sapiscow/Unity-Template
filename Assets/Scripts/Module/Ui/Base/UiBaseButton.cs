using DG.Tweening;
using Sapiscow.Framework.Signal;
using Sapiscow.UnityTemplate.Module.Audios;
using Sapiscow.UnityTemplate.Module.Audios.Signal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sapiscow.UnityTemplate.Module.Ui
{
    public class UiBaseButton : Button
    {
        protected const float _pressedScale = 0.85f;
        protected const float _pressedBouncePower = 5f;
        protected const float _tweenDuration = 0.15f;

        [SerializeField] protected AudioSfx _buttonClickedSfx = AudioSfx.Select;
        [SerializeField] protected bool _useTween = true;

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (_useTween && interactable)
                targetGraphic.transform.DOScale(Vector3.one * _pressedScale, _tweenDuration);

            base.OnPointerDown(eventData);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            if (_useTween && interactable)
                targetGraphic.transform.DOScale(Vector3.one, _tweenDuration).SetEase(Ease.OutBack, _pressedBouncePower);

            base.OnPointerUp(eventData);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (interactable && _buttonClickedSfx != AudioSfx.None)
                SignalManager.Publish(new AudioPlaySfxSignal(_buttonClickedSfx));

            base.OnPointerClick(eventData);
        }
    }
}