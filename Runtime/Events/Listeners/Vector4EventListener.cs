using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Vector4 Event Listener")]
    public class Vector4EventListener : ASOEventListener<Vector4>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<Vector4>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<Vector4>
        {
            [SerializeField] private Vector4Event _soEvent;
            public override ASOEvent<Vector4> SOEvent => _soEvent;

            [SerializeField] private UnityEventVector4 _response;
            public override UnityEvent<Vector4> Response => _response;
        }
    }
}