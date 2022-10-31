using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LiteNinja.SOA.Events
{
    public abstract class ASOEvent<T> : ScriptableEventBase, IDrawObjectsInInspector
    {
        private readonly List<ASOEventListener<T>> eventListeners = new();

        [SerializeField]
        private bool _debugLogEnabled;
        
        [SerializeField]
        protected T _debugValue;
        
        public void Raise(T param)
        {
            if (!Application.isPlaying)
                return;

            for (var i = eventListeners.Count - 1; i >= 0; i--)
                eventListeners[i].OnEventRaised(this, param, _debugLogEnabled);
        }

        public void RegisterListener(ASOEventListener<T> listener)
        {
            if (!eventListeners.Contains(listener)) eventListeners.Add(listener);
        }

        public void UnregisterListener(ASOEventListener<T> listener)
        {
            if (eventListeners.Contains(listener))eventListeners.Remove(listener);
        }

        public List<Object> GetAllObjects()
        {
            var goList = new List<Object>(eventListeners.Count);
            goList.AddRange(eventListeners.Select(eventListener => eventListener.gameObject));
            return goList;
        }
    }
}