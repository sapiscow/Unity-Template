using DG.Tweening;
using Sapiscow.Framework.Injection;
using Sapiscow.Framework.Signal;
using Sapiscow.UnityTemplate.Module.Audios;
using Sapiscow.UnityTemplate.Module.Audios.Signal;
using Sapiscow.UnityTemplate.Module.Inputs;
using Sapiscow.UnityTemplate.Module.Ui.Signal;
using UnityEngine;
using UnityEngine.UI;

namespace Sapiscow.UnityTemplate.Module.Ui
{
    public abstract class UiBasePopup : MonoBehaviour, IInputLayerObject
    {
        protected const float _tweenShowDuration = 0.2f;
        protected const float _tweenHideDuration = 0.15f;

        [SerializeField] protected bool _isCloseable = true;
        [SerializeField] protected CanvasGroup _canvasGroup;
        [SerializeField] protected RectTransform _frameRect;
        [SerializeField] protected Button _overlayButton;

        public event System.Action OnClosed;

        protected virtual void Awake()
        {
            DependencyInjection.Inject(this);

            InitComponentsListeners();
        }

        protected virtual void Reset()
        {
            _overlayButton = GetComponent<Button>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _frameRect = transform.GetChild(0).GetComponent<RectTransform>();
        }

        public virtual void Show()
        {
            DOTween.Kill(_canvasGroup);
            _canvasGroup.alpha = 0f;
            _canvasGroup.blocksRaycasts = true;

            gameObject.SetActive(true);
            _canvasGroup.DOFade(1f, _tweenShowDuration);

            SignalManager.Publish(new UiPopupShowedSignal(this));
            OnShowed();
        }

        public virtual void Hide()
        {
            _canvasGroup.blocksRaycasts = false;

            _canvasGroup.DOFade(0f, _tweenHideDuration).OnComplete(() =>
            {
                OnClosed?.Invoke();
                gameObject.SetActive(false);
            });

            SignalManager.Publish(new UiPopupHiddenSignal());
            OnHidden();
        }

        protected virtual void TriggerOnClosed()
            => OnClosed?.Invoke();

        protected virtual void OnShowed() { }
        protected virtual void OnHidden() { }

        public virtual void OnBackButtonPressed()
        {
            if (_isCloseable)
            {
                SignalManager.Publish(new AudioPlaySfxSignal(AudioSfx.Cancel));
                Hide();
            }
        }

        #region Components Listeners
        protected virtual void InitComponentsListeners()
            => _overlayButton.onClick.AddListener(OnOverlayButtonClicked);

        protected virtual void OnOverlayButtonClicked()
        {
            if (_isCloseable)
            {
                SignalManager.Publish(new AudioPlaySfxSignal(AudioSfx.Cancel));
                Hide();
            }
        }
        #endregion
    }
}