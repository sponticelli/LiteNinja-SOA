using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/AudioClip Event Listener")]
    public class AudioClipListener : ASOEventListener<AudioClip>
    {
        [SerializeField] private EventResponse[] _eventResponses;
        protected override EventResponse<AudioClip>[] EventResponses => _eventResponses;

        [System.Serializable]
        public class EventResponse : EventResponse<AudioClip>
        {
            [SerializeField] private AudioClipEvent _soEvent;
            public override ASOEvent<AudioClip> SOEvent => _soEvent;

            [SerializeField] private UnityEventAudioClip _response;
            public override UnityEvent<AudioClip> Response => _response;
        }
    }
}