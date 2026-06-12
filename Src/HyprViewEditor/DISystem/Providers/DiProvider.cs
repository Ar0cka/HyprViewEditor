using HyprViewEditor.DISystem.DiInterfaces;
using HyprViewEditor.DISystem.DiSystem;

namespace HyprViewEditor.DISystem.Providers;

/// <summary>
/// For usage this provide, override BindingInstance
/// </summary>
public abstract class DiProvider
{
    protected readonly IBindingDiContainer DiContainer = Di.BindingInstance;

    public virtual void BindingInstance()
    {
        
    }
}