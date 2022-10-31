using System;
using LiteNinja.SOA.Variables;

namespace LiteNinja.SOA.References
{
  [Serializable]
  public class FloatRef
  {
    public bool UseLocal;
    public float LocalValue;
    public FloatVar Variable;

    public FloatRef()
    {
    }

    public FloatRef(float value)
    {
      UseLocal = true;
      LocalValue = value;
    }

    public float Value
    {
      get => UseLocal ? LocalValue : Variable.Value;
      set
      {
        if (UseLocal)
          LocalValue = value;
        else
          Variable.Value = value;
      }
    }

    public static implicit operator float(FloatRef reference)
    {
      return reference.Value;
    }
  }
}