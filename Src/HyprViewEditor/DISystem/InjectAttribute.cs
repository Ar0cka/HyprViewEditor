using System;

namespace HyprViewEditor.DISystem;


[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class InjectAttribute : Attribute
{
}