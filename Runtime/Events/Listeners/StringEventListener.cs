using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/String Event Listener")]
    public class StringEventListener : ASOEventListener<string>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<string>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<string>
        {
            [SerializeField] private StringEvent _soEvent;
            public override ASOEvent<string> SOEvent => _soEvent;

            [SerializeField] private UnityEventString _response;
            public override UnityEvent<string> Response => _response;
        }
    }
}