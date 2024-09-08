using Sapiscow.Framework.Signal;

namespace Sapiscow.UnityTemplate.Module.Ui.Signal
{
    public readonly struct UiPopupShowedSignal : ISignal
    {
        public UiBasePopup Popup { get; }

        public UiPopupShowedSignal(UiBasePopup popup)
        {
            Popup = popup;
        }
    }
}