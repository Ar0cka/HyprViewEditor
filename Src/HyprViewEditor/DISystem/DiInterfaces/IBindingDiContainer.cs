using System;
using HyprViewEditor.DISystem.Binders;

namespace HyprViewEditor.DISystem.DiInterfaces;

public interface IBindingDiContainer
{
    public BinderGeneric Bind<TContract>();
    public BindingInstance BindInstance<TContract>();
    public ScopeBinder FromInstance<TInstance>();

    public void BindSingleton(Type type, object instance);
}