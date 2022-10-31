using System;
using LiteNinja.SOA.References;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Variables
{
  public class BindComparisonToUnityEvent : MonoBehaviour
  {
    public CustomVariableType Type = CustomVariableType.NONE;

    public BoolVar boolVariable;
    public bool boolVariableComparer;
        
    public IntRef intReference;
    public IntRef intReferenceComparer;
        
    public FloatRef floatReference;
    public FloatRef floatReferenceComparer;
        
    public StringRef stringReference;
    public StringRef stringReferenceComparer;

    public Operation operation = Operation.EQUAL;
        
    [SerializeField] private UnityEvent _unityEvent = new();
        
    private void Awake()
    {
      Subscribe();
    }

    private void Start()
    {
      Evaluate();
    }

    private void Evaluate()
    {
      switch (Type)
      {
        case CustomVariableType.BOOL:
          Evaluate(boolVariable.Value);
          break;
        case CustomVariableType.INT:
          Evaluate(intReference.Value);
          break;
        case CustomVariableType.FLOAT:
          Evaluate(floatReference.Value);
          break;
        case CustomVariableType.STRING:
          Evaluate(stringReference.Value);
          break;
        case CustomVariableType.NONE:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void Evaluate(bool value)
    {
      if (value == boolVariableComparer)
        _unityEvent.Invoke();
    }

    private void Evaluate(int value)
    {
      switch (operation)
      {
        case Operation.EQUAL:
          if (value == intReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        case Operation.SMALLER:
          if (value < intReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        case Operation.BIGGER:
          if (value > intReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        case Operation.BIGGER_OR_EQUAL:
          if (value >= intReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        case Operation.SMALLER_OR_EQUAL:
          if (value <= intReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void Evaluate(float value)
    {
      switch (operation)
      {
        case Operation.EQUAL:
          if (Mathf.Approximately(value, floatReferenceComparer.Value))
            _unityEvent.Invoke();
          break;
        case Operation.SMALLER:
          if (value < floatReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        case Operation.BIGGER:
          if (value > floatReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        case Operation.BIGGER_OR_EQUAL:
          if (value >= floatReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        case Operation.SMALLER_OR_EQUAL:
          if (value <= floatReferenceComparer.Value)
            _unityEvent.Invoke();
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void Evaluate(string value)
    {
      if (value.Equals(stringReferenceComparer.Value))
        _unityEvent.Invoke();
    }

    private void Subscribe()
    {
      switch (Type)
      {
        case CustomVariableType.BOOL:
          boolVariable.OnValueChanged += Evaluate;
          break;
        case CustomVariableType.INT:
          intReference.Variable.OnValueChanged += Evaluate;
          break;
        case CustomVariableType.FLOAT:
          floatReference.Variable.OnValueChanged += Evaluate;
          break;
        case CustomVariableType.STRING:
          stringReference.Variable.OnValueChanged += Evaluate;
          break;
        case CustomVariableType.NONE:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    private void OnDestroy()
    {
      switch (Type)
      {
        case CustomVariableType.BOOL:
          boolVariable.OnValueChanged -= Evaluate;
          break;
        case CustomVariableType.INT:
          intReference.Variable.OnValueChanged -= Evaluate;
          break;
        case CustomVariableType.FLOAT:
          floatReference.Variable.OnValueChanged -= Evaluate;
          break;
        case CustomVariableType.STRING:
          stringReference.Variable.OnValueChanged -= Evaluate;
          break;
        case CustomVariableType.NONE:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

    public enum Operation
    {
      EQUAL,
      SMALLER,
      BIGGER,
      BIGGER_OR_EQUAL,
      SMALLER_OR_EQUAL
    }
  }
}