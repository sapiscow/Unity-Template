using Sapiscow.Framework.Injection;
using UnityEngine;

namespace Sapiscow.UnityTemplate.Module.Ui
{
    public abstract class UiBasePanel : MonoBehaviour
    {
        public event System.Action OnClosed;

        protected virtual void Awake()
        {
            DependencyInjection.Inject(this);

            InitComponentsListeners();
        }

        public virtual void Show()
            => gameObject.SetActive(true);

        public virtual void Hide()
        {
            OnClosed?.Invoke();
            gameObject.SetActive(false);
        }

        protected virtual void TriggerOnClosed()
            => OnClosed?.Invoke();

        protected virtual void InitComponentsListeners() { }
    }
}