using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Vector3 Event Listener")]
    public class Vector3EventListener : ASOEventListener<Vector3>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<Vector3>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<Vector3>
        {
            [SerializeField] private Vector3Event _soEvent;
            public override ASOEvent<Vector3> SOEvent => _soEvent;

            [SerializeField] private UnityEventVector3 _response;
            public override UnityEvent<Vector3> Response => _response;
        }
    }
}