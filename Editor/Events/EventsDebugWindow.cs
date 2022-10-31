using System.Collections.Generic;
using System.Linq;
using LiteNinja.SOA.Events;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace LiteNinja.SOA.Editor
{
  public class EventsDebugWindow : EditorWindow
  {
    [MenuItem("Window/LiteNinja/SOA/Event Debug Window")]
    public new static void Show()
    {
      GetWindow<EventsDebugWindow>("Events Debug Window");
    }

    private string _methodName = string.Empty;

    private void OnGUI()
    {
      _methodName = EditorGUILayout.TextField("Method Name", _methodName);

      if (GUILayout.Button("Find"))
      {
        FindMethod(_methodName);
      }
    }

    private void FindMethod(string methodName)
    {
      var eventListeners = FindAllInOpenScenes<ASOEventListenerBase>();

      var found = eventListeners.Any(listener => listener.ContainsCallToMethod(methodName));

      if (!found)
      {
        Debug.Log("<color=#52D5F2>" + methodName + "()</color>" + " could not be found in the listeners in the scene");
      }
    }

    private static List<T> FindAllInOpenScenes<T>()
    {
      var results = new List<T>();
      for (var i = 0; i < SceneManager.sceneCount; i++)
      {
        var s = SceneManager.GetSceneAt(i);
        if (!s.isLoaded) continue;
        
        var allGameObjects = s.GetRootGameObjects();
        foreach (var go in allGameObjects)
        {
          results.AddRange(go.GetComponentsInChildren<T>(true));
        }
      }

      return results;
    }
  }
}