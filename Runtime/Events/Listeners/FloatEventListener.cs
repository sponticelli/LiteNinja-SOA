using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Float Event Listener")]
    public class FloatEventListener : ASOEventListener<float>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<float>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<float>
        {
            [SerializeField] private FloatEvent _soEvent;
            public override ASOEvent<float> SOEvent => _soEvent;

            [SerializeField] private UnityEventFloat _response;
            public override UnityEvent<float> Response => _response;
        }
    }
}