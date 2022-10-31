using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Vector2 Event Listener")]
    public class Vector2EventListener : ASOEventListener<Vector2>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<Vector2>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<Vector2>
        {
            [SerializeField] private Vector2Event _soEvent;
            public override ASOEvent<Vector2> SOEvent => _soEvent;

            [SerializeField] private UnityEventVector2 _response;
            public override UnityEvent<Vector2> Response => _response;
        }
    }
}