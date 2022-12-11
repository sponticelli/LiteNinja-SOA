using System;
using System.Globalization;
using System.Text;
using TMPro;
using UnityEngine;

namespace LiteNinja.SOA.Variables
{
  [RequireComponent(typeof(TMP_Text))]
  public class BindTextMeshPro : CacheComponent<TMP_Text>
  {
    [SerializeField] public CustomVariableType Type = CustomVariableType.NONE;
        
    [SerializeField] private BoolVar _boolVariable;
    [SerializeField] private IntVar _intVariable;
    [SerializeField] private FloatVar _floatVariable;
    [SerializeField] private StringVar _stringVariable;

    public string Prefix = string.Empty;
    public string Suffix = string.Empty;

    [Header("Int Variable")]
    [Tooltip("Useful too an offset, for example for Level counts. If your level index is  0, add 1, so it displays Level : 1")]
    public int Increment;

    [Header("Float Variable")]
    [Tooltip("For float, you can specify the number of decimal to display")]
    [Min(1)]
    public int DecimalAmount = 2;
    
    
    [Header("Culture Info")]
    public bool useCultureInfo;
    public CultureInfo Culture = CultureInfo.CurrentCulture;

    private readonly StringBuilder _stringBuilder = new StringBuilder();

    protected override void Awake()
    {
      base.Awake();
      if (Type == CustomVariableType.NONE)
      {
        Debug.LogError("Select a type for this binding component", gameObject);
        return;
      }
            
      Refresh();
      Subscribe();
    }

    private void Refresh()
    {
      _stringBuilder.Clear();
      _stringBuilder.Append(Prefix);

      switch (Type)
      {
        case CustomVariableType.BOOL:
          _stringBuilder.Append(_boolVariable.ToString());
          break;
        case CustomVariableType.INT:
          var amount = _intVariable.Value + Increment;
          _stringBuilder.Append(useCultureInfo ? amount.ToString("N0", Culture) : amount.ToString());
          break;
        case CustomVariableType.FLOAT:
          var rounded = System.Math.Round(_floatVariable.Value, DecimalAmount);
          _stringBuilder.Append(rounded);
          break;
        case CustomVariableType.STRING:
          _stringBuilder.Append(_stringVariable.ToString());
          break;
        case CustomVariableType.NONE:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }

      _stringBuilder.Append(Suffix);
      _component.text = _stringBuilder.ToString();
    }

    private void Subscribe()
    {
      switch (Type)
      {
        case CustomVariableType.BOOL:
          if (_boolVariable != null)
            _boolVariable.OnValueChanged += (value)=> Refresh();
          break;
        case CustomVariableType.INT:
          if (_intVariable != null)
            _intVariable.OnValueChanged += (value)=> Refresh();
          break;
        case CustomVariableType.FLOAT:
          if (_floatVariable != null)
            _floatVariable.OnValueChanged += (value)=> Refresh();
          break;
        case CustomVariableType.STRING:
          if (_stringVariable != null)
            _stringVariable.OnValueChanged += (value)=> Refresh();
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
          if (_boolVariable != null)
            _boolVariable.OnValueChanged -= (value)=> Refresh();
          break;
        case CustomVariableType.INT:
          if (_intVariable != null)
            _intVariable.OnValueChanged -= (value)=> Refresh();
          break;
        case CustomVariableType.FLOAT:
          if (_floatVariable != null)
            _floatVariable.OnValueChanged -= (value)=> Refresh();
          break;
        case CustomVariableType.STRING:
          if (_stringVariable != null)
            _stringVariable.OnValueChanged -= (value)=> Refresh();
          break;
        case CustomVariableType.NONE:
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }

  }
}