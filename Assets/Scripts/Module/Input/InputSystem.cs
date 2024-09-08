using Sapiscow.Framework.Systems;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Sapiscow.UnityTemplate.Module.Inputs
{
    public class InputSystem : BaseSystemMono, IInputSystem
    {
        private List<IInputLayer> _inputLayers = new();

        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                foreach (IInputLayer layer in _inputLayers)
                {
                    IInputLayerObject layerObject = layer.GetFirstLayerObject();
                    if (layerObject != null)
                    {
                        layerObject.OnBackButtonPressed();
                        return;
                    }
                }
            }
        }

        public void AddInputLayer(IInputLayer layer)
        {
            _inputLayers.Add(layer);
            _inputLayers.Sort((a, b) => b.Priority.CompareTo(a.Priority));
        }
    }
}