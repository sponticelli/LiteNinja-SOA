using LiteNinja.SOA.References;
using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.SOA.Variables
{
  [RequireComponent(typeof(Image))]
  public class BindFillingImage : CacheComponent<Image>
  {
    [SerializeField] private FloatVar _floatVariable;
    [SerializeField] private FloatRef _maxValue;

    protected override void Awake()
    {
      base.Awake();
      _floatVariable.OnValueChanged += Refresh;
    }

    private void OnEnable()
    {
      Refresh(_floatVariable.Value);
    }

    private void OnDestroy()
    {
      _floatVariable.OnValueChanged -= Refresh;
    }

    private void Refresh(float currentValue)
    {
      _component.fillAmount = _floatVariable.Value / _maxValue.Value;
    }
  }
}