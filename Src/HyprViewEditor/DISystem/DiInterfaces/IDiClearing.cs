using System;

namespace HyprViewEditor.DISystem.DiInterfaces;

public interface IDiClearing
{
    public void UnsubscribeAll();
    public void ClearAll();
    public void UnsubscribeInstance(Type type);
}