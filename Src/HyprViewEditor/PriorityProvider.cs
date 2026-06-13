using HyprViewEditor.DISystem.Enums;
using HyprViewEditor.DISystem.Providers;
using HyprViewEditor.Scripts.Options;
using HyprViewEditor.Scripts.Options.Interfaces;

namespace HyprViewEditor;

public class PriorityProvider : DiProvider
{
    public override void BindingInstance()
    {
        DiContainer.Bind<IOptionsController>().To<OptionsController>().ScopeBind(ScopeType.Singleton, false);
    }
}