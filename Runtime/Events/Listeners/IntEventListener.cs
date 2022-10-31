using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Int Event Listener")]
    public class IntEventListener : ASOEventListener<int>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<int>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<int>
        {
            [SerializeField] private IntEvent _soEvent;
            public override ASOEvent<int> SOEvent => _soEvent;

            [SerializeField] private UnityEventInt _response;
            public override UnityEvent<int> Response => _response;
        }
    }
}