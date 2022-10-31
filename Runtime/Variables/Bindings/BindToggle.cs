using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.SOA.Variables
{
  [RequireComponent(typeof(Toggle))]
  public class BindToggle : CacheComponent<Toggle>
  {
    [SerializeField] private BoolVar _boundVariable;

    protected override void Awake()
    {
      base.Awake();
      OnValueChanged(_boundVariable.Value);
      _component.onValueChanged.AddListener(SetBoundVariable);
      _boundVariable.OnValueChanged += OnValueChanged;
    }

    private void OnDestroy()
    {
      _component.onValueChanged.RemoveListener(SetBoundVariable);
      _boundVariable.OnValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(bool value)
    {
      _component.isOn = value;
    }

    private void SetBoundVariable(bool value)
    {
      _boundVariable.Value = value;
    }
  }
}