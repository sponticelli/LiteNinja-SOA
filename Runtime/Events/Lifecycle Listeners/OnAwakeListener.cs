using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Unity Events/Awake Listener")]
    public class OnAwakeListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent awakeEvent;

        private void Awake()
        {
            awakeEvent.Invoke();
        }
    }
    
}