using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Quaternion Event Listener")]
    public class QuaternionEventListener : ASOEventListener<Quaternion>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<Quaternion>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<Quaternion>
        {
            [SerializeField] private QuaternionEvent _soEvent;
            public override ASOEvent<Quaternion> SOEvent => _soEvent;

            [SerializeField] private UnityEventQuaternion _response;
            public override UnityEvent<Quaternion> Response => _response;
        }
    }
}