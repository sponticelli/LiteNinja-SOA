using UnityEngine;

namespace LiteNinja.SOA.Events
{
  public abstract class ASOEventListenerBase : MonoBehaviour
  {
    protected enum Binding
    {
      UNTIL_DESTROY,
      UNTIL_DISABLE
    }
        
    [SerializeField] protected Binding _binding = Binding.UNTIL_DESTROY;

    [SerializeField] protected bool _disableAfterSubscribing;

    protected abstract void ToggleRegistration(bool toggle);

    public abstract bool ContainsCallToMethod(string methodName);
        
    protected virtual void Awake()
    {
      if (_binding == Binding.UNTIL_DESTROY)
        ToggleRegistration(true);

      gameObject.SetActive(!_disableAfterSubscribing);
    }

    protected virtual void OnEnable()
    {
      if (_binding == Binding.UNTIL_DISABLE)
        ToggleRegistration(true);
    }

    protected void OnDisable()
    {
      if (_binding == Binding.UNTIL_DISABLE)
        ToggleRegistration(false);
    }

    protected void OnDestroy()
    {
      if (_binding == Binding.UNTIL_DESTROY)
        ToggleRegistration(false);
    }

  }
}