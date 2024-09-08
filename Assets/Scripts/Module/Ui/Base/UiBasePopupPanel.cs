using Sapiscow.Framework.Signal;
using Sapiscow.UnityTemplate.Module.Inputs;
using Sapiscow.UnityTemplate.Module.Ui.Signal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sapiscow.UnityTemplate.Module.Ui
{
    public abstract class UiBasePopupPanel : UiBasePanel, IInputLayer
    {
        protected static readonly WaitForEndOfFrame _frameDelayer = new();

        protected Stack<UiBasePopup> _showedPopups = new();
        protected Queue<UiBasePopup> _popupQueue = new();

        protected IInputSystem _inputSystem;

        public int Priority => 1;

        protected override void Awake()
        {
            base.Awake();
            _inputSystem.AddInputLayer(this);

            SignalManager.Subscribe<UiPopupShowedSignal>(OnUiPopupShowed);
            SignalManager.Subscribe<UiPopupHiddenSignal>(OnUiPopupHidden);
        }

        protected T InstantiatePopup<T>(T instance, T prefab) where T : UiBasePopup
        {
            if (instance == null)
            {
                instance = Instantiate(prefab, transform);
                instance.gameObject.SetActive(false);
            }

            return instance;
        }

        protected void ShowOrQueuePopup(UiBasePopup popup)
        {
            StartCoroutine(Routine());
            IEnumerator Routine()
            {
                yield return _frameDelayer;

                if (_showedPopups.Count > 0) _popupQueue.Enqueue(popup);
                else popup.Show();
            }
        }

        public IInputLayerObject GetFirstLayerObject()
        {
            if (_showedPopups.TryPeek(out UiBasePopup popup))
                return popup;

            return null;
        }

        #region Signal Subscriptions
        private void OnUiPopupShowed(UiPopupShowedSignal signal)
            => _showedPopups.Push(signal.Popup);

        private void OnUiPopupHidden(UiPopupHiddenSignal signal)
        {
            _showedPopups.Pop();
            if (_showedPopups.Count <= 0 && _popupQueue.TryDequeue(out UiBasePopup popup))
                popup.Show();
        }
        #endregion
    }
}