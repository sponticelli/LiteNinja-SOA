using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Color Event Listener")]
    public class ColorEventListener : ASOEventListener<Color>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<Color>[] EventResponses => _eventResponses;

        [System.Serializable]
        public class EventResponse : EventResponse<Color>
        {
            [SerializeField] private ColorEvent _soEvent;
            public override ASOEvent<Color> SOEvent => _soEvent;

            [SerializeField] private UnityEventColor _response;
            public override UnityEvent<Color> Response => _response;
        }
    }
}