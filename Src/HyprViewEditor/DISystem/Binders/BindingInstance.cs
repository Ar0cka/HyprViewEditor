using HyprViewEditor.DISystem.DiInterfaces;

namespace HyprViewEditor.DISystem.Binders;

public class BindingInstance(IFinalizedBinding diContainer, BindingInstanceInfo bindingInfo)
{
    private readonly IFinalizedBinding _diContainer = diContainer;
    private readonly BindingInstanceInfo _bindingInfo = bindingInfo;
    
    public void ToInstance(object instance)
    {
        _bindingInfo.Instance = instance;
        
        _diContainer.FinalizeInstanceBinding(_bindingInfo);
    }
}