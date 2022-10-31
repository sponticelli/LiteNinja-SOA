using System;
using LiteNinja.SOA.Variables;

namespace LiteNinja.SOA.References
{
  [Serializable]
  public class IntRef
  {
    public bool UseConstant;
    public int ConstantValue;
    public IntVar Variable;

    public IntRef()
    {
    }

    public IntRef(int value)
    {
      UseConstant = true;
      ConstantValue = value;
    }

    public int Value
    {
      get => UseConstant ? ConstantValue : Variable.Value;
      set
      {
        if (UseConstant)
          ConstantValue = value;
        else
          Variable.Value = value;
      }
    }

    public static implicit operator int(IntRef reference)
    {
      return reference.Value;
    }
  }
  
  [Serializable]
  public class StringRef
  {
    public bool UseConstant;
    public string ConstantValue;
    public StringVar Variable;

    public StringRef()
    {
    }

    public StringRef(string value)
    {
      UseConstant = true;
      ConstantValue = value;
    }

    public string Value
    {
      get => UseConstant ? ConstantValue : Variable.Value;
      set
      {
        if (UseConstant)
          ConstantValue = value;
        else
          Variable.Value = value;
      }
    }

    public static implicit operator string(StringRef reference)
    {
      return reference.Value;
    }
  }
}