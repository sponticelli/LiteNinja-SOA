using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Unity Events/Start Listener")]
    public class OnStartListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent startEvent;

        private void Start()
        {
            startEvent.Invoke();
        }
    }
}