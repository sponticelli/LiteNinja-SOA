using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
    [AddComponentMenu("LiteNinja/Event Listeners/Game Event Listener")]
    public class GameEventListener : ASOEventListenerBase
    {
        [SerializeField] private EventResponse[] _eventResponses;

        private Dictionary<GameEvent, UnityEvent> _dictionary = new();

        /// <summary>
        /// Add a EventResponse to _eventResponses
        /// </summary>
        /// <param name="eventResponse"></param>
        public void AddEventResponse(EventResponse eventResponse)
        {
            List<EventResponse> list = new(_eventResponses) { eventResponse };
            _eventResponses = list.ToArray();
        }
        
        /// <summary>
        /// Remove a EventResponse from _eventResponses
        /// </summary>
        /// <param name="eventResponse"></param>
        public void RemoveEventResponse(EventResponse eventResponse)
        {
            List<EventResponse> list = new(_eventResponses);
            if (!list.Contains(eventResponse)) return;
            list.Remove(eventResponse);
            _eventResponses = list.ToArray();
        }
       
        
        
        protected override void ToggleRegistration(bool toggle)
        {
            for (var i = 0; i < _eventResponses.Length; i++)
            {
                if (toggle)
                {
                    _eventResponses[i].ScriptableEvent.RegisterListener(this);
                    
                    if(!_dictionary.ContainsKey(_eventResponses[i].ScriptableEvent))
                        _dictionary.Add(_eventResponses[i].ScriptableEvent, _eventResponses[i].Response);
                }
                else
                {
                    _eventResponses[i].ScriptableEvent.UnregisterListener(this);
                    if(_dictionary.ContainsKey(_eventResponses[i].ScriptableEvent))
                        _dictionary.Remove(_eventResponses[i].ScriptableEvent);
                }
            }
        }

        public void OnEventRaised(GameEvent eventRaised, bool debug = false)
        {
            _dictionary[eventRaised].Invoke();

            if (debug)
                Debug(eventRaised);
        }

        [System.Serializable]
        public struct EventResponse
        {
            public GameEvent ScriptableEvent;
            public UnityEvent Response;
        }

        #region Debugging

        private void Debug(GameEvent eventRaised)
        {
            var listener = _dictionary[eventRaised];
            var registeredListenerCount = listener.GetPersistentEventCount();

            for (var i = 0; i < registeredListenerCount; i++)
            {
                var debugText = $"<color=#52D5F2>[Event] ";
                debugText += eventRaised.name;
                debugText += " => </color>";
                debugText += listener.GetPersistentTarget(i);
                debugText += ".";
                debugText += listener.GetPersistentMethodName(i);
                debugText += "()";
                UnityEngine.Debug.Log(debugText, gameObject);
            }
        }

        public override bool ContainsCallToMethod(string methodName)
        {
            var containsMethod = false;
            foreach (var eventResponse in _eventResponses)
            {
                var registeredListenerCount = eventResponse.Response.GetPersistentEventCount();

                for (var i = 0; i < registeredListenerCount; i++)
                {
                    if (eventResponse.Response.GetPersistentMethodName(i) == methodName)
                    {
                        var debugText = $"<color=#52D5F2>{methodName}()</color>";
                        debugText += " is called by the event: <color=#52D5F2>";
                        debugText += eventResponse.ScriptableEvent.name;
                        debugText += "</color>";
                        UnityEngine.Debug.Log(debugText, gameObject);
                        containsMethod = true;
                        break;
                    }
                }
            }

            return containsMethod;
        }

        #endregion
    }
}