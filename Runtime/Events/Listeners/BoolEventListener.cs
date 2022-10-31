using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Bool Event Listener")]
    public class BoolEventListener : ASOEventListener<bool>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<bool>[] EventResponses => _eventResponses;

        [System.Serializable]
        public class EventResponse : EventResponse<bool>
        {
            [SerializeField] private BoolEvent _soEvent;
            public override ASOEvent<bool> SOEvent => _soEvent;

            [SerializeField] private UnityEventBool _response;
            public override UnityEvent<bool> Response => _response;
        }
    }
}