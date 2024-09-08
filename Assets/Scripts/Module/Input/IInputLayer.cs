namespace Sapiscow.UnityTemplate.Module.Inputs
{
    public interface IInputLayer
    {
        int Priority { get; }

        IInputLayerObject GetFirstLayerObject();
    }
}