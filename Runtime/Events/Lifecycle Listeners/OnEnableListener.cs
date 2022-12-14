using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Unity Events/OnEnable Listener")]
    public class OnEnableListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent enableEvent;

        private void OnEnable()
        {
            enableEvent.Invoke();
        }
    }
}