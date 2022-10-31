using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    [CreateAssetMenu(menuName = "LiteNinja/Events/Game Event")]
    [System.Serializable]
    public class GameEvent : ScriptableObject, IDrawObjectsInInspector
    {
        [SerializeField] 
        private bool _debugLogEnabled;

        private readonly List<GameEventListener> _eventListeners = new();
        
        public void Raise()
        {
            if (!Application.isPlaying) return;

            for (var i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(this, _debugLogEnabled);
        }
        
        public void RegisterListener(GameEventListener listener)
        {
            if (!_eventListeners.Contains(listener)) _eventListeners.Add(listener);
        }
        

        public void UnregisterListener(GameEventListener listener)
        {
            if (_eventListeners.Contains(listener)) _eventListeners.Remove(listener);
        }

        public List<Object> GetAllObjects()
        {
            var goList = new List<Object>(_eventListeners.Count);
            goList.AddRange(_eventListeners.Select(eventListener => eventListener.gameObject));
            return goList;
        }
    }
}