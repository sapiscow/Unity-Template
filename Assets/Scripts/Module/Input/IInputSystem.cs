using Sapiscow.Framework.Systems;

namespace Sapiscow.UnityTemplate.Module.Inputs
{
    public interface IInputSystem : ISystem
    {
        void AddInputLayer(IInputLayer layer);
    }
}