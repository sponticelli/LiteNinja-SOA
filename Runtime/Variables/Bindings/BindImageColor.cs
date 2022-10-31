using UnityEngine;
using UnityEngine.UI;

namespace LiteNinja.SOA.Variables
{
  [RequireComponent(typeof(Image))]
  public class BindImageColor : CacheComponent<Image>
  {
    [SerializeField] private ColorVar _colorVariable;
      
    protected override void Awake()
    {
      base.Awake();
      _colorVariable.OnValueChanged += Refresh;
    }

    private void OnEnable()
    {
      Refresh(_colorVariable.Value);
    }

    private void OnDestroy()
    {
      _colorVariable.OnValueChanged -= Refresh;
    }

    private void Refresh(Color color)
    {
      _component.color = color;
    }
  }
}