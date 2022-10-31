using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Component Event Listener")]
    public class ComponentEventListener : ASOEventListener<Component>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<Component>[] EventResponses => _eventResponses;

        [System.Serializable]
        public class EventResponse : EventResponse<Component>
        {
            [SerializeField] private ComponentEvent _soEvent;
            public override ASOEvent<Component> SOEvent => _soEvent;

            [SerializeField] private UnityEventComponent _response;
            public override UnityEvent<Component> Response => _response;
        }
    }
}