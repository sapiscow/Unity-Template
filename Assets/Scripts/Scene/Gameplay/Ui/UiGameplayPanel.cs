using Sapiscow.Framework.Signal;
using Sapiscow.UnityTemplate.Module.Ui;
using Sapiscow.UnityTemplate.Scene.Gameplay.Ui.Signal;
using UnityEngine;
using UnityEngine.UI;

namespace Sapiscow.UnityTemplate.Scene.Gameplay.Ui
{
    public class UiGameplayPanel : UiBasePanel
    {
        [Header("Components")]
        [SerializeField] private Button _sampleButton;

        protected override void InitComponentsListeners()
        {
            base.InitComponentsListeners();

            _sampleButton.onClick.AddListener(OnSampleButtonClicked);
        }

        private void OnSampleButtonClicked()
            => SignalManager.Publish(new UiGameplayPopupSampleShowedSignal());
    }
}