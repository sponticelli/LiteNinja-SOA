using System;
using UnityEngine;

namespace LiteNinja.SOA
{
  [Serializable]
  public abstract class ScriptableBase : ScriptableObject
  {
#if UNITY_EDITOR
    [SerializeField] [TextArea] private string _description;
#endif    
  }

  [Serializable]
  public abstract class ScriptableVariableBase : ScriptableBase
  {
  }

  [Serializable]
  public abstract class ScriptableListBase : ScriptableBase
  {
  }

  [Serializable]
  public abstract class ScriptableEventBase : ScriptableBase
  {
  }
}