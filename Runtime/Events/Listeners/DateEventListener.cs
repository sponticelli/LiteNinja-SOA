using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/DateTime Event Listener")]
    public class DateTimeEventListener : ASOEventListener<DateTime>
    { 
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<DateTime>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<DateTime>
        {
            [SerializeField] private DateTimeEvent _soEvent;
            public override ASOEvent<DateTime> SOEvent => _soEvent;

            [SerializeField] private UnityEventDateTime _response;
            public override UnityEvent<DateTime> Response => _response;
        }
    }
}