using System;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
  [CreateAssetMenu(menuName = "LiteNinja/Variables/Float Var", fileName = "FloatVar")]
  [Serializable]
  public class FloatVar : ASOVar<float>
  {
    public override void Save()
    {
      PlayerPrefs.SetFloat(name, Value);
      base.Save();
    }

    public override void Load()
    {
      if (PlayerPrefs.HasKey(name))
      {
        Value = PlayerPrefs.GetFloat(name);
      }
      else
      {
        initialValue  = Value;
      }
      
      base.Load();
    }

    public void Add(float value)
    {
      Value += value;
    }
  }
}