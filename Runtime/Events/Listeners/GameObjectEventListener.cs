using System;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/GameObject Event Listener")]
    public class GameObjectEventListener : ASOEventListener<GameObject>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<GameObject>[] EventResponses => _eventResponses;

        [Serializable]
        public class EventResponse : EventResponse<GameObject>
        {
            [SerializeField] private GameObjectEvent _soEvent;
            public override ASOEvent<GameObject> SOEvent => _soEvent;

            [SerializeField] private UnityEventGameObject _response;
            public override UnityEvent<GameObject> Response => _response;
        }
    }
}