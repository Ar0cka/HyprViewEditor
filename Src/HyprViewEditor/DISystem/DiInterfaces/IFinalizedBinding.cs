using HyprViewEditor.DISystem.Binders;

namespace HyprViewEditor.DISystem.DiInterfaces;

public interface IFinalizedBinding
{
    public void FinalizeBinding(BindingInfo bindingInfo);
    public void FinalizeInstanceBinding(BindingInstanceInfo bindingInfo);
}