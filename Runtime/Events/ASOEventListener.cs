using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Events;

namespace LiteNinja.SOA.Events
{
  public abstract class ASOEventListener<T> : ASOEventListenerBase
  {
    protected virtual EventResponse<T>[] EventResponses { get; }

    private readonly Dictionary<ASOEvent<T>, UnityEvent<T>> _dictionary = new();

    public void OnEventRaised(ASOEvent<T> scriptableEventRaised, T param, bool debug = false)
    {
      _dictionary[scriptableEventRaised].Invoke(param);

      if (debug)
        Debug(scriptableEventRaised);
    }

    protected override void ToggleRegistration(bool toggle)
    {
      foreach (var t in EventResponses)
      {
        if (toggle)
        {
          t.SOEvent.RegisterListener(this);
          if (!_dictionary.ContainsKey(t.SOEvent)) _dictionary.Add(t.SOEvent, t.Response);
        }
        else
        {
          t.SOEvent.UnregisterListener(this);
          if (_dictionary.ContainsKey(t.SOEvent)) _dictionary.Remove(t.SOEvent);
        }
      }
    }

    private void Debug(ASOEvent<T> eventRaised)
    {
      var listener = _dictionary[eventRaised];
      var registeredListenerCount = listener.GetPersistentEventCount();

      for (var i = 0; i < registeredListenerCount; i++)
      {
        var sb = new StringBuilder();
        sb.Append($"<color=#52D5F2>[Event] </color>");
        sb.Append(eventRaised.name);
        sb.Append(" => ");
        sb.Append(listener.GetPersistentTarget(i).name);
        sb.Append(".");
        sb.Append(listener.GetPersistentMethodName(i));
        sb.Append("()");
        UnityEngine.Debug.Log(sb.ToString(), gameObject);
      }
    }

    public override bool ContainsCallToMethod(string methodName)
    {
      var containsMethod = false;
      foreach (var eventResponse in EventResponses)
      {
        var registeredListenerCount = eventResponse.Response.GetPersistentEventCount();

        for (var i = 0; i < registeredListenerCount; i++)
        {
          if (eventResponse.Response.GetPersistentMethodName(i) != methodName) continue;

          var sb = new StringBuilder();
          sb.Append($"<color=#52D5F2>{methodName}()</color>");
          sb.Append(" is called by: <color=#52D5F2>[Event] ");
          sb.Append(eventResponse.SOEvent.name);
          sb.Append("</color>");
          UnityEngine.Debug.Log(sb.ToString(), gameObject);
          containsMethod = true;
          break;
        }
      }

      return containsMethod;
    }

    [Serializable]
    public class EventResponse<U>
    {
      public virtual ASOEvent<U> SOEvent { get; }
      public virtual UnityEvent<U> Response { get; }
    }
  }
}