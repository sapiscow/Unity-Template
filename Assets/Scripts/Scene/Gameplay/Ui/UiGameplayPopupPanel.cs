using Sapiscow.Framework.Signal;
using Sapiscow.UnityTemplate.Module.Ui;
using Sapiscow.UnityTemplate.Scene.Gameplay.Ui.Signal;
using UnityEngine;

namespace Sapiscow.UnityTemplate.Scene.Gameplay.Ui
{
    public class UiGameplayPopupPanel : UiBasePopupPanel
    {
        [Header("Prefabs")]
        [SerializeField] private UiGameplaySamplePopup _samplePopupPrefab;

        private UiGameplaySamplePopup _samplePopup;

        protected override void Awake()
        {
            base.Awake();

            SignalManager.Subscribe<UiGameplayPopupSampleShowedSignal>(OnPopupCollectionShowed);
        }

        #region Signal Subscriptions
        private void OnPopupCollectionShowed(UiGameplayPopupSampleShowedSignal signal)
        {
            _samplePopup = InstantiatePopup(_samplePopup, _samplePopupPrefab);
            _samplePopup.Show();
        }
        #endregion
    }
}